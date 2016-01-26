using System;
using System.Collections.Generic;

namespace WebApplication2.ViewModels.Autore
{
    public class AutoreViewModel
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string RawBiography { get; set; }

        public int? ArticlesCount { get; set; }

        public int? NewsCount { get; set; }

        public int? TipsCount { get; set; }

        public int? ForumRepliesCount { get; set; }

        public string BlogSite { get; set; }

        public string FacebookSite { get; set; }

        public string GooglePlusSite { get; set; }

        public string TwitterAccount { get; set; }

        public IEnumerable<Content> LatestContents { get; set; }

        public class Content
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public DateTime PublishedDate { get; set; }

            public string Section { get; set; }
        } 
    }
}
