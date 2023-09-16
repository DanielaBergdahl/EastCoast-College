using AutoMapper;
using EastCoastEducation.Dto;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using EastCoastEducation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EastCoastEducation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceController : Controller
    {
        private readonly ICompetenceRepository _competenceRepository;
        private readonly IMapper _mapper;

        public CompetenceController(ICompetenceRepository competenceRepository, IMapper mapper)
        {
            _competenceRepository = competenceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Competence>))]
        public IActionResult GetAllCompetences()
        {
            var competences = _mapper.Map<List<CompetenceDto>>(_competenceRepository.GetAllCompetences());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(competences);
        }

        [HttpGet("{competenceId}")]
        [ProducesResponseType(200, Type = typeof(Competence))]
        [ProducesResponseType(400)]
        public IActionResult GetComptetenceById(int competenceId)
        {
            if (!_competenceRepository.CompetenceExists(competenceId))
                return NotFound();

            var competence = _mapper.Map<CompetenceDto>(_competenceRepository.GetCompetence(competenceId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(competence);
        }
    }
}
