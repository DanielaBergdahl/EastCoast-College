using EastCoastEducation.Model;

namespace EastCoastEducation.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudent(int id); // details, för att kunna se lista på kurser som studenten köpt
        bool StudentExists(int id);
        //bool CreateStudent(int courseId, Student student);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);    
        bool Save();
        
        bool DeleteStudent(Student student);
        bool AddCourseToStudent(StudentCourse studentCourse);
    }
}
