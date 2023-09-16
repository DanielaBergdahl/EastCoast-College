using EastCoastAdmin.Models;
using EastCoastAdmin.Helpers;
using EastCoastAdmin.Services.Interfaces;
using System.Text.Json.Nodes;

namespace EastCoastAdmin.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Teachers/GetTeachers/";

        public TeacherService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<TeacherViewModel>> Find()
        {
            var response = await _client.GetAsync("/api/Teachers/GetTeachers/");
            return await response.ReadContentAsync<List<TeacherViewModel>>();
        }

        public async Task<TeacherViewModel> Find(int id)
        {
            var response = await _client.GetAsync("/api/Teachers/GetTeacher/" + id);
            return await response.ReadContentAsync<TeacherViewModel>();
        }

        public async Task<HttpResponseMessage> Update(StringContent content, int id)
        {
            var response = await _client.PutAsync("/api/Teachers/PutTeacher/" + id, content);
            return await response.ReadContentAsync<HttpResponseMessage>();
        }

        public async Task<HttpResponseMessage> Add(StringContent content)
        {
            var response = await _client.PostAsync("/api/Teachers/PostTeacher", content);
            return await response.ReadContentAsync<HttpResponseMessage>();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var response = await _client.DeleteAsync("/api/Teachers/DeleteTeacher/" + id);
            return response;
        
        }
    }
}
