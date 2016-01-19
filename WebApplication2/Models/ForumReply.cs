using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ForumReply
    {
        public int Id { get; set; }

        [Required]
        public Thread Thread { get; set; }

        [Required]
        public Author Author { get; set; }

        public ForumReply Parent { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
