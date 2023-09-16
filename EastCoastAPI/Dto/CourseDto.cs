namespace EastCoastEducation.Dto
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public int CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public string CourseLength { get; set; }
        public string Category { get; set; }
        public string? CourseDescription { get; set; }
        public string? CourseDetails { get; set; }
    }
}
