using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ForumGroup
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
