using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Contact
{
    public int Uniqueid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime Createddate { get; set; }
}
