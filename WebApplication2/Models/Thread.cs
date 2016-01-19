using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Thread
    {
        public int Id { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public ForumGroup Group { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public IList<ForumReply> Replies { get; set; }  
    }
}