 using Microsoft.AspNetCore.Mvc.Rendering;

namespace EastCoastAdmin.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }

        public List<CourseViewModel>? CurrentCourses { get; set; } = new List<CourseViewModel>();
        public List<SelectListItem>? EligibleCourses { get; set; } = new List<SelectListItem>();

        
    }
}
