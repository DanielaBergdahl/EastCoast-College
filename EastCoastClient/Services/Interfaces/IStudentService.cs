using EastCoastAdmin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EastCoastAdmin.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> Find();
        Task AddCourseToStudent(StringContent content, int id);

    }
}
