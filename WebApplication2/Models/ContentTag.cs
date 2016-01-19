using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ContentTag
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public IList<Content> Contents { get; set; } 
    }
}
