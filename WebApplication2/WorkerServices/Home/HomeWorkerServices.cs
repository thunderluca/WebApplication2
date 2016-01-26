using System.Linq;
using WebApplication2.ViewModels.Home;

namespace WebApplication2.WorkerServices.Home
{
    public class HomeWorkerServices
    {
        public IndexViewModel GetIndexViewModel()
        {
            using (var context = new Models.UgiContext())
            {
                var contents = (from content in context.Contents
                                orderby content.PublishedDate descending
                                select new IndexViewModel.Content
                                {
                                    Id = content.Id,
                                    Title = content.Title,
                                    Abstract = content.Abstract,
                                    PublishedDate = content.PublishedDate,
                                    AuthorId = content.Author.Id,
                                    AuthorName = content.Author.Name + " " + content.Author.Surname,
                                    Section = content is Models.Articolo ? "Articolo" : (content is Models.News ? "News" : "Tip")
                                }).Take(10).ToList();

                var threads = (from thread in context.Threads
                               select new IndexViewModel.Thread
                               {
                                   Id = thread.Id,
                                   Title = thread.Title,
                                   PublishedDate = thread.PublishedDate
                               }).OrderByDescending(thread => thread.PublishedDate).Take(5).ToList();

                var blogPosts = (from blogPost in context.Blogs
                                 select new IndexViewModel.BlogPost
                                 {
                                     Id = blogPost.Id,
                                     Title = blogPost.Title,
                                     Author = blogPost.Author,
                                     Permalink = blogPost.Permalink,
                                     PublishedDate = blogPost.PublishedDate
                                 }).OrderByDescending(blogPost => blogPost.PublishedDate).Take(5).ToList();

                var mediaPosts = (from media in context.MediaPosts
                                  select new IndexViewModel.MediaPost
                                  {
                                      Id = media.Id,
                                      Title = media.Title,
                                      Preview = media.Preview,
                                      PublishedDate = media.PublishedDate
                                  }).OrderByDescending(media => media.PublishedDate).Take(5).ToList();

                var model = new IndexViewModel
                {
                    LatestContents = contents,
                    LatestBlogPosts = blogPosts,
                    LatestMedia = mediaPosts,
                    LatestThreads = threads
                };

                return model;
            }
        }
    }
}
