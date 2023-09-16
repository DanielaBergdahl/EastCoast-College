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

        public async Task AddCourseToStudent(StringContent content, int id)
        {
            var response = await _client.PostAsync(BasePath + "AddCourseToStudent/" + id, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            return;
        }

    }
}
