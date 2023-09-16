using EastCoastAdmin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EastCoastAdmin.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> Find();
        Task<StudentViewModel> Find(int id);
        Task<HttpResponseMessage> Update(StringContent content, int id);
        Task<HttpResponseMessage> Add(StringContent content);
        Task AddCourseToStudent(StringContent content, int id);
        //Task<HttpResponseMessage> AddCourseToStudent(StringContent content, int id);

        Task<StudentViewModel> AddCurrentAndEligibleCourses(StudentViewModel student, int id);
        void Delete(int id);
    }
}
