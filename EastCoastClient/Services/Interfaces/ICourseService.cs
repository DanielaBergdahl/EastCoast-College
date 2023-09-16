using EastCoastAdmin.Models;

namespace EastCoastAdmin.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseViewModel>> Find();
        Task<CourseViewModel> Find(int id);

        Task<CourseViewModel> AddEligibleStudents(CourseViewModel course);
    }
}
