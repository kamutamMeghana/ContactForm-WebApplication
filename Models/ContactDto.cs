using System.ComponentModel.DataAnnotations;

namespace ContactForm.Models
{
    public class ContactDto
    {
        public int uniqueid { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
