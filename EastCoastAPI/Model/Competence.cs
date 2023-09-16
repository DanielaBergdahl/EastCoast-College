namespace EastCoastEducation.Model
{
    public class Competence
    {
        public int CompetenceId { get; set; }
        public string CompetenceName { get; set; }

        ////-------------------------------------------------------------------------
        ////Create a many-to-many relationship
        //public ICollection<TeacherCompetence> TeacherCompetences { get; set; }
        ////-------------------------------------------------------------------------

        public List<Teacher> Teachers { get; } = new();
        public List<TeacherCompetence> TeacherCompetences { get; } = new();
    }
}
