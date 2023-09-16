using EastCoastEducation.Model;

namespace EastCoastEducation.Interfaces
{
    public interface ICourseRepository
    { 
        ICollection<Course> GetAllCourses();
        Course GetCourse(int id);
        bool CourseExists(int id);
        bool CreateCourse(Course course);
        bool UpdateCourse(Course course);
        bool Save();

        ICollection<Course> GetCoursesByStudentId(int id);

        //Kanske ej använder nedanstående metoder, de kan vara helt fel
        Course GetCourse(string title);
        Course GetCourseByCategory(string category);
        //nummer kategori detaljer
        Course GetCourseByNumber(int number);
        Course GetCourseByDetails(string details);
        Course GetCourseByLength(string length);


    }
}
