using AutoMapper;
using EastCoastEducation.Dto;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using EastCoastEducation.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace EastCoastEducation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController2 : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController2(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudents()
        {
            var students = _mapper.Map<List<Student>>(_studentRepository.GetStudents());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(students);
        }

        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult GetStudentById(int studentId)
        {
            if (!_studentRepository.StudentExists(studentId))
                return NotFound();

            var student = _mapper.Map<StudentDto>(_studentRepository.GetStudent(studentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(student);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        //En mall för Teacher som ska skapas samtidigt som relationen till en kurs läggs till +
        // relationen till kompetens
        //public IActionResult CreateStudent([FromQuery] int courseId, [FromBody] StudentDto studentCreate)
        //public IActionResult CreateStudent([FromBody] int courseId, [FromBody] StudentDto studentCreate)
        public IActionResult CreateStudent([FromBody] StudentDto studentCreate)
        {
            if (studentCreate == null)
                return BadRequest(ModelState);

            var students = _studentRepository.GetStudents()
                .Where(s => s.StudentId == studentCreate.StudentId)
                .FirstOrDefault();

            if (students != null)
            {
                ModelState.AddModelError("", "Student already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentMap = _mapper.Map<Student>(studentCreate);

            //if (!_studentRepository.CreateStudent(courseId, studentMap))
            if (!_studentRepository.CreateStudent(studentMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPost("{studentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult AddCourseToStudent(int studentId, [FromBody] StudentCourse studentCourse)
        {
            if (studentCourse == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            _studentRepository.AddCourseToStudent(studentCourse);
            return NoContent();
        }

        [HttpPut("{studentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateStudent(int studentId, [FromBody] StudentDto updatedStudent)
        {
            if (updatedStudent == null)
                return BadRequest(ModelState);

            if (!_studentRepository.StudentExists(studentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var studentMap = _mapper.Map<Student>(updatedStudent);

            if (!_studentRepository.UpdateStudent(studentMap))
            {
                ModelState.AddModelError("", "Something went wrong when updating student");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{studentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStudent(int studentId)
        {
            if (!_studentRepository.StudentExists(studentId))
            {
                return NotFound();
            }

            var studentToDelete = _studentRepository.GetStudent(studentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_studentRepository.DeleteStudent(studentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }

    }
}
