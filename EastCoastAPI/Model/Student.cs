namespace EastCoastEducation.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }

        ////--------------------
        ////Create a many-to-many relationship...(according to tutorial 1.)
        //public ICollection <StudentCourse> StudentCourses { get; set; }

        ////----------------

        public List<Course> Courses { get; } = new();
        public List<StudentCourse> StudentCourses { get; } = new();
    }
}
