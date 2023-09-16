using  Microsoft.EntityFrameworkCore;

namespace EastCoastEducation.Model
{
    [Index(nameof(CourseNumber), nameof(CourseTitle), IsUnique = true)]
    public class Course
    {
        public int CourseId { get; set; }
        public int CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public string CourseLength { get; set; }
        public string Category { get; set; }
        public string? CourseDescription { get; set; }
        public string? CourseDetails { get; set; }
        
        //TeacherId is the principal key (Entity Framework term)
        //public int? TeacherId { get; set; }
        //public Teacher? Teacher { get; set; } = null!;

        ////Tutorial 1.----------
        ////Create many-to-many relationship FOREIGN KEY
        //public ICollection<StudentCourse> StudentCourses { get; set; }
        ////-----------------

        public List<Student>? Students { get; } = new();
        public List<StudentCourse>? StudentCourses { get; } = new();
    }
}
