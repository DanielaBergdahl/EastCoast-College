namespace EastCoastEducation.Model
{
    public class TeacherCompetence
    {
        public int CompetenceId { get; set; }
        public int TeacherId { get; set; }
        public Competence Competence { get; set; }
        public Teacher Teacher { get; set; }
    }
}
