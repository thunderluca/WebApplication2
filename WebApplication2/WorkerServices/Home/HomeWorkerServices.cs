using System.Linq;
using WebApplication2.Models;
using WebApplication2.ViewModels.Home;

namespace WebApplication2.WorkerServices.Home
{
    public class HomeWorkerServices
    {
        public HomeViewModel GetHomeModel()
        {
            using (var context = new UgiContext())
            {
                var contents = (from content in context.Contents
                                select new HomeViewModel.Content
                                {
                                    Id = content.Id,
                                    Title = content.Title,
                                    SectionTitle = content.Section.Title,
                                    Excerpt = content.Abstract,
                                    Published = content.PublishedDate,
                                    AuthorId = content.Author.Id,
                                    AuthorName = content.Author.Name + " " + content.Author.Surname
                                }).ToList();

                var threads = (from thread in context.Threads
                               select new HomeViewModel.Thread
                               {
                                   Id = thread.Id,
                                   Title = thread.Title
                               }).ToList();

                var blogPosts = (from blogPost in context.Blogs
                                 select new HomeViewModel.BlogPost
                                 {
                                     Id = blogPost.Id,
                                     Title = blogPost.Title,
                                     Author = blogPost.Author,
                                     Permalink = blogPost.Permalink,
                                     Published = blogPost.Published
                                 }).ToList();

                var mediaPosts = (from media in context.MediaPosts
                                  select new HomeViewModel.MediaPost
                                  {
                                      Id = media.Id,
                                      Title = media.Title,
                                      Preview = media.Preview
                                  }).ToList();

                var model = new HomeViewModel
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
