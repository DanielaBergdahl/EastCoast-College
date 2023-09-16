using EastCoastAdmin.Models;
using EastCoastAdmin.Helpers;
using EastCoastAdmin.Services.Interfaces;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EastCoastAdmin.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/StudentsController2/";

        public StudentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<StudentViewModel>> Find()
        {
            var response = await _client.GetAsync(BasePath + "GetStudents/");
            return await response.ReadContentAsync<List<StudentViewModel>>();
        }

        // find a single student + add a list of all courses for the view
        public async Task<StudentViewModel> Find(int id)
        {
            var student = new StudentViewModel();
            var response = await _client.GetAsync(BasePath + "GetStudentById/" + id);
            student = await response.ReadContentAsync<StudentViewModel>();

            await AddCurrentAndEligibleCourses(student, id);
            return student;
        }

        public async Task<StudentViewModel> AddCurrentAndEligibleCourses(StudentViewModel student, int id)
        {
            //get all courses
            var response = await _client.GetAsync("/api/Courses/GetCourses/");
            var allCourses = await response.ReadContentAsync<List<CourseViewModel>>();

            //get current courses for this student
            response = await _client.GetAsync("/api/Courses/GetCoursesByStudentId/" + id);
            var currentCourses = await response.ReadContentAsync<List<CourseViewModel>>();
            foreach (var course in currentCourses)
            {
                student.CurrentCourses.Add(new CourseViewModel { CourseId = course.CourseId, CourseTitle = course.CourseTitle });
            }

            var eligibleCourses = allCourses.Except(currentCourses).ToList();

            foreach (var course in eligibleCourses)
            {
                student.EligibleCourses.Add(new SelectListItem { Value = course.CourseId.ToString(), Text = course.CourseTitle });
            }
            return student;

        }

        public async Task<HttpResponseMessage> Update(StringContent content, int id)
        {
            var response = await _client.PutAsync(BasePath + "UpdateStudent/" + id, content);
            string responseBody = await response.Content.ReadAsStringAsync();

            return await response.ReadContentAsync<HttpResponseMessage>();
        }

        public async Task<HttpResponseMessage> Add(StringContent content)
        {
            var response = await _client.PostAsync(BasePath + "CreateStudent", content);
            return await response.ReadContentAsync<HttpResponseMessage>();
        }

        public async Task AddCourseToStudent(StringContent content, int id)
        {
            var response = await _client.PostAsync(BasePath + "AddCourseToStudent/" + id, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            return;
        }

        public async void Delete(int id)
        {
            var response = await _client.DeleteAsync(BasePath + "DeleteStudent/" + id);
            return;

        }
    }
}
