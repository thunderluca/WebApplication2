using System;
using System.Collections.Generic;

namespace WebApplication2.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Content> LatestContents { get; set; }
        
        public IEnumerable<Thread> LatestThreads { get; set; }
        
        public IEnumerable<MediaPost> LatestMedia { get; set; }
        
        public IEnumerable<BlogPost> LatestBlogPosts { get; set; } 

        public class Content
        {
            public int Id { get; set; }
            
            public string Title { get; set; }
            
            public DateTime Published { get; set; }
            
            public int AuthorId { get; set; }

            public string AuthorName { get; set; }
            
            public string Excerpt { get; set; }

            public string SectionTitle { get; set; }
        }

        public class BlogPost
        {
            public int Id { get; set; }
            
            public string Title { get; set; }
            
            public string Author { get; set; }
            
            public string Permalink { get; set; }
            
            public DateTime Published { get; set; }
        }

        public class MediaPost
        {
            public int Id { get; set; }
            
            public string Title { get; set; }
            
            public string Preview { get; set; }
        }

        public class Thread
        {
            public int Id { get; set; }
            
            public string Title { get; set; }
        }
    }
}