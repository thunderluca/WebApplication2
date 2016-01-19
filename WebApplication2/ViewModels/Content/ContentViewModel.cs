using System;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.ViewModels.Content
{
    public class ContentViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public DateTime PublishedDate { get; set; }

        public IEnumerable<ContentTag> Tags { get; set; }

        public IEnumerable<Content> LatestArticles { get; set; }

        public class Content
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Body { get; set; }

            public DateTime PublishedDate { get; set; }

            public int AuthorId { get; set; }

            public string AuthorName { get; set; }
        }
    }
}
