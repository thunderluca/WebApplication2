using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class MediaPost
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Preview { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public MediaAlbum Album { get; set; }

        public IList<ContentTag> Tags { get; set; } 

        public IList<Author> Speaker { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}