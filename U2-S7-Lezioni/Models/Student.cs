using System;
using System.ComponentModel.DataAnnotations;

namespace U2_S7_Lezioni.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Required, MaxLength(50)]
        public string Cognome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
