using System;
using System.Collections.Generic;

namespace WebApplication2.ViewModels.Forum
{
    public class ThreadViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public IEnumerable<ForumReply> Replies { get; set; } 

        public DateTime PublishedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public class ForumReply
        {
            public int ThreadId { get; set; }

            public int Id { get; set; }

            public string Body { get; set; }

            public int? ParentId { get; set; }

            public string ParentAuthorName { get; set; }

            public int AuthorId { get; set; }

            public string AuthorName { get; set; }

            public DateTime PublishedDate { get; set; }

            public DateTime ModifiedDate { get; set; }
        }
    }
}