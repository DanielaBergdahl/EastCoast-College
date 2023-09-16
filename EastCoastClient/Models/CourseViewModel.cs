using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Xml.Linq;

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
        
        [DisplayName("Kursbeskrivning")]
        public string CourseDescription { get; set; }

        [DisplayName("Kursdetaljer")]
        public string CourseDetails { get; set; }

        public List<SelectListItem>? EligibleStudents { get; set; } = new List<SelectListItem>();

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
