using System;

namespace ContactForm.Models
{
    public partial class Contact
    {
        public int Uniqueid { get; set; }   // ✅ matches DB primary key
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Createddate { get; set; }
    }
}
