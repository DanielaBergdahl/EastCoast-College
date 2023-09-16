using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;


namespace EastCoastAdmin.Models
{
    public class StudentViewModel
    {
        
        public int StudentId { get; set; }
        
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        
        [DisplayName("E-post")]
        public string Email { get; set; }
        
        [DisplayName("Mobiltelefon")]
        public string MobilePhone { get; set; }
        
        [DisplayName("Adress")]
        public string Address { get; set; }

        public List<CourseViewModel>? CurrentCourses { get; set; } = new List<CourseViewModel>();
        public List<SelectListItem>? EligibleCourses { get; set; } = new List<SelectListItem>();

        
    }
}
