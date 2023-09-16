using EastCoastEducation.Model;

namespace EastCoastEducation.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        //Task<Teacher?> GetTeacher(int id);
        Teacher GetTeacher(int id);
        bool TeacherExists(int id);
        bool CreateTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool Save();
        //void Delete(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);
    }
}
