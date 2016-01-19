using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Permalink { get; set; }

        [Required]
        public DateTime Published { get; set; }
    }
}