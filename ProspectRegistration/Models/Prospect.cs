using System.ComponentModel.DataAnnotations;

namespace ProspectRegistration.Models
{
    public class Prospect
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required] 
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Comment { get; set; }

    }
}
