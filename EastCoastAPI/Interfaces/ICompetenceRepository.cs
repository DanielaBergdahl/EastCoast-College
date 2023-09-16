using EastCoastEducation.Model;

namespace EastCoastEducation.Interfaces
{
    public interface ICompetenceRepository
    {
        ICollection<Competence> GetAllCompetences();
        Competence GetCompetence(int id);
        bool CompetenceExists(int id);
    } 
}
