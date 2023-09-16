using System.ComponentModel;

namespace EastCoastAdmin.Models
{
    public class CourseViewModel : IEquatable<CourseViewModel>
    {
        public int CourseId { get; set; }
        
        [DisplayName("Kurskod")]
        public int CourseNumber { get; set; }

        [DisplayName("Kurstitel")]
        public string CourseTitle { get; set; }
        
        [DisplayName("Kurslängd")]
        public string CourseLength { get; set; }
        
        [DisplayName("Kategori")]
        public string Category { get; set; }
        
        [DisplayName("Beskrivning")]
        public string CourseDescription { get; set; }

        [DisplayName("Detaljer")]
        public string CourseDetails { get; set; }

        public bool Equals(CourseViewModel other)
        {
            if (other is null)
                return false;
            return this.CourseId == other.CourseId;
        }

        public override bool Equals(object obj) => Equals(obj as CourseViewModel);
        public override int GetHashCode() => (CourseId).GetHashCode();
    }
}
