using EastCoastAdmin.Models;
using EastCoastAdmin.Helpers;
using EastCoastAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EastCoastAdmin.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Courses/GetCourses/";

        public CourseService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CourseViewModel>> Find()
        {
            var response = await _client.GetAsync("/api/Courses/GetCourses/");
            return await response.ReadContentAsync<List<CourseViewModel>>();
        }

        public async Task<CourseViewModel> Find(int id)
        {
            var course = new CourseViewModel();
            var response = await _client.GetAsync("/api/Courses/GetCourseById/" + id);
            course = await response.ReadContentAsync<CourseViewModel>();
            
            await AddEligibleStudents(course);
            return course;
        }

        public async Task<CourseViewModel> AddEligibleStudents(CourseViewModel course)
        {
            var response = await _client.GetAsync("/api/StudentsController2/GetStudents");
            var allStudents =  await response.ReadContentAsync<List<StudentViewModel>>();
            foreach (var student in allStudents)
            {
                course.EligibleStudents.Add(new SelectListItem { Value = "" + student.StudentId, Text = student.FirstName + " "  + student.LastName });
            }
            return course;
        }




    }
}
