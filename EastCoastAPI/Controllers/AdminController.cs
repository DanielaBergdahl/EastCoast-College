//using EastCoastEducation.Interfaces;
//using EastCoastEducation.Model;
//using Microsoft.AspNetCore.Mvc;

//namespace EastCoastEducation.Controllers
//{
//    public class AdminController : ControllerBase
//    {
//        private readonly IStudentRepository _studentRepository;
//        private readonly ICourseRepository _courseRepository;
//        private readonly ITeacherRepository _teacherRepository;
//        public AdminController(
//            IStudentRepository studentRepository,
//            ICourseRepository courseRepository,
//            ITeacherRepository teacherRepository)
//        {
//            _studentRepository = studentRepository;
//            _courseRepository = courseRepository;
//            _teacherRepository = teacherRepository;
//        }

//        public ActionResult<IEnumerable<Student>> GetAllStudents()
//            => _studentRepository.GetStudents().ToList();
//        public ActionResult<bool> CreateStudent(Student student)
//            => _studentRepository.CreateStudent(student);
//        public ActionResult<bool> EditStudent(Student student)
//            => _studentRepository.UpdateStudent(student);

//        public ActionResult<IEnumerable<Course>> GetAllCourses()
//            => _courseRepository.GetAllCourses().ToList();
//        public ActionResult<bool> CreateCourse(Course course)
//            => _courseRepository.CreateCourse(course);
//        public ActionResult EditCourse() { }

//        public ActionResult GetAllTeachers() { }
//        public ActionResult CreateTeacher() { }
//        public ActionResult EditTeacher() { }
//    }
//}
