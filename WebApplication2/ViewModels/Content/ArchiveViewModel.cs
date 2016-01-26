using System;
using System.Collections.Generic;

namespace WebApplication2.ViewModels.Content
{
    public class ArchiveViewModel
    {
        public IEnumerable<Content> Contents { get; set; }

        public IEnumerable<ContentTag> Tags { get; set; } 

        public int PageIndex { get; set; }

        public int TotalPageCount { get; set; }

        public int? SelectedTagId { get; set; }

        public string SelectedTagTitle { get; set; }

        public class Content
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Body { get; set; }

            public DateTime PublishedDate { get; set; }

            public int AuthorId { get; set; }

            public string AuthorName { get; set; }
        }

        public class ContentTag
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string UnescapedTitle { get; set; }
        }
    }
}
