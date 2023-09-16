namespace EastCoastEducation.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public string? Address { get; set; }
        public string? Competence { get; set; }

        // Create a one-to-many relationship...
        public ICollection<Course> Courses { get; } = new List<Course>(); // Course is dependent (a child to) Teacher.
                                                                          // In the one to many relationship
                                                                          // this is the "one" end.

        ////------------------------------------------------------------------------
        ////Create a many-to-many relationship...
        //public ICollection<TeacherCompetence> TeacherCompetences { get; set; }
        ////------------------------------------------------------------------------
        public List<Competence> Competences { get; } = new();
        public List<TeacherCompetence> TeacherCompetences { get; } = new();

    }
}
