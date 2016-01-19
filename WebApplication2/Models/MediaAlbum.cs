using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class MediaAlbum
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public IList<MediaPost> MediaPosts { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
