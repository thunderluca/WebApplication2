using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Content
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Abstract { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        public Author Author { get; set; }

        public IList<ContentTag> Tags { get; set; }

        [Required]
        public ContentSection Section { get; set; }
    }
}
