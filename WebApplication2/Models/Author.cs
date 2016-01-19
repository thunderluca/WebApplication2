using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Biography { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public string BlogSite { get; set; }

        public string FacebookSite { get; set; }

        public string GooglePlusSite { get; set; }

        public string TwitterAccount { get; set; }
    }
}