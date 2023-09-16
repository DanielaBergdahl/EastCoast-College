using EastCoastAdmin.Models;
using EastCoastAdmin.Helpers;
using EastCoastAdmin.Services.Interfaces;

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
            var response = await _client.GetAsync("/api/Courses/GetCourseById/" + id);
            return await response.ReadContentAsync<CourseViewModel>();
        }

        public async Task<HttpResponseMessage> Update(StringContent content, int id)
        {
            var response = await _client.PutAsync("/api/Courses/UpdateCourse?courseId=" + id, content);
            return await response.ReadContentAsync<HttpResponseMessage>();
        }

        public void Add(StringContent content)
        {
            var response = _client.PostAsync("/api/Courses/CreateCourse", content);
        }

        //public async Task<HttpResponseMessage> Add(StringContent content)
        //{
        //    var response = await _client.PostAsync("/api/Courses/CreateCourse", content);
        //    return await response.ReadContentAsync<HttpResponseMessage>();
        //}



    }
}
