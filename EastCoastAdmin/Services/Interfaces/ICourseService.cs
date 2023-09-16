using EastCoastAdmin.Models;

namespace EastCoastAdmin.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseViewModel>> Find();
        Task<CourseViewModel> Find(int id);
        Task<HttpResponseMessage> Update(StringContent content, int id);
        void Add(StringContent content);
        //Task<HttpResponseMessage> Add(StringContent content);
    }
}
