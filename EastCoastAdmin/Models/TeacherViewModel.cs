using System.ComponentModel;

namespace EastCoastAdmin.Models
{
    public class TeacherViewModel
    {
        [DisplayName("Anställningsnummer")]
        public int TeacherId { get; set; }
        
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("E-post")]
        public string? Email { get; set; }

        [DisplayName("Mobiltelefon")]
        public string? MobilePhone { get; set; }
        [DisplayName("Adress")]
        public string? Address { get; set; }
        [DisplayName("Kompetenser")]
        public string? Competence { get; set; }

    }
}
