using Microsoft.AspNetCore.Mvc;
using EastCoastEducation.Model;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Dto;
using AutoMapper;
using EastCoastEducation.Repository;

namespace EastCoastEducation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
          return Ok(await _teacherRepository.GetTeachers());
        }

        [HttpGet("{teacherId}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public IActionResult GetTeacher(int teacherId)
        {
            if (!_teacherRepository.TeacherExists(teacherId))
                return NotFound();

            var teacher = _mapper.Map<TeacherDto>(_teacherRepository.GetTeacher(teacherId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public IActionResult PutTeacher(TeacherDto teacherDto)
        {
            try
            {
                var updatedTeacher = _teacherRepository.UpdateTeacher(_mapper.Map<Teacher>(teacherDto));
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Teacher> PostTeacher(TeacherDto teacherDto)
        {
            try
            {
                var createdTeacher = _teacherRepository.CreateTeacher(_mapper.Map<Teacher>(teacherDto));
                return Ok(createdTeacher);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{teacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTeacher(int teacherId)
        {
            if (!_teacherRepository.TeacherExists(teacherId))
            {
                return NotFound();
            }

            var teacherToDelete = _teacherRepository.GetTeacher(teacherId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teacherRepository.DeleteTeacher(teacherToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }




    }
}
