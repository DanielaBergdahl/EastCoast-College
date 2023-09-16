using AutoMapper;
using EastCoastEducation.Dto;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace EastCoastEducation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper= mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult GetCourses()
        {
            var courses = _mapper.Map<List<CourseDto>>(_courseRepository.GetAllCourses());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        [ProducesResponseType(200, Type = typeof(Course))]
        [ProducesResponseType(400)]
        public IActionResult GetCourseById(int courseId)
        {
            if (!_courseRepository.CourseExists(courseId))
                return NotFound();

            var course = _mapper.Map<CourseDto>(_courseRepository.GetCourse(courseId)); 

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(course);
        }



        [HttpGet("{studentId}")]
        public IActionResult GetCoursesByStudentId([FromRoute] int studentId)
        {
            //var course = _mapper.Map<CourseDto>(_courseRepository.GetCoursesByStudentId(studentId));
            var course = _courseRepository.GetCoursesByStudentId(studentId);

            return Ok(course);
        }

        //Add Post
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCourse([FromBody] CourseDto courseCreate)
        {
            if (courseCreate == null)
                return BadRequest(ModelState);

            var courses = _courseRepository.GetAllCourses()
                .Where(c => c.CourseTitle.Trim().ToUpper() == courseCreate.CourseTitle.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (courses != null)
            {
                ModelState.AddModelError("", "Course already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseMap = _mapper.Map<Course>(courseCreate);

            if (!_courseRepository.CreateCourse(courseMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        //[HttpPut("{courseId}")]
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateCourse(int courseId, [FromBody] CourseDto updatedCourse)
        {
            if (updatedCourse == null)
                return BadRequest(ModelState);

            if (!_courseRepository.CourseExists(courseId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var courseMap = _mapper.Map<Course>(updatedCourse);

            if (!_courseRepository.UpdateCourse(courseMap))
            {
                ModelState.AddModelError("", "Something went wrong updating course");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


    }
}
