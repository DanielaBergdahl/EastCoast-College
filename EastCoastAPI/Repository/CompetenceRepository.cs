using EastCoastEducation.Data;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using SQLitePCL;

namespace EastCoastEducation.Repository
{
    public class CompetenceRepository : ICompetenceRepository
    {
        private readonly ApplicationDbContext _context;

        public CompetenceRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public bool CompetenceExists(int id)
        {
            return _context.Competences.Any(c => c.CompetenceId == id); 
        }

        public Competence GetCompetence(int id)
        {
            return _context.Competences.Where(c => c.CompetenceId == id).FirstOrDefault();
        }

        public ICollection<Competence> GetCompetences()
        {
            return _context.Competences.ToList();
        }
        public ICollection<Competence> GetAllCompetences()
        {
            return _context.Competences.OrderBy(c => c.CompetenceId).ToList();
        }

    }
}
