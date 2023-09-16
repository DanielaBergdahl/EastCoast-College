using EastCoastAdmin.Models;

namespace EastCoastAdmin.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherViewModel>> Find();
        Task<TeacherViewModel> Find(int id);
        Task<HttpResponseMessage> Update(StringContent content, int id);
        Task<HttpResponseMessage> Add(StringContent content);
        Task<HttpResponseMessage> Delete(int id);
    }
}
