using System.Collections.Generic;
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
                var mixedContents = context.Contents.OrderByDescending(content => content.PublishedDate).Take(10).ToList();

                var contents = new List<IndexViewModel.Content>();
                foreach (var content in mixedContents)
                {
                    if (content is Models.Articolo)
                    {
                        var article = new IndexViewModel.Article
                        {
                            Id = content.Id,
                            Title = content.Title,
                            Abstract = content.Abstract,
                            PublishedDate = content.PublishedDate,
                            AuthorId = content.Author.Id,
                            AuthorName = content.Author.Name + " " + content.Author.Surname
                        };

                        contents.Add(article);
                    }

                    if (content is Models.News)
                    {
                        var news = new IndexViewModel.News
                        {
                            Id = content.Id,
                            Title = content.Title,
                            Abstract = content.Abstract,
                            PublishedDate = content.PublishedDate,
                            AuthorId = content.Author.Id,
                            AuthorName = content.Author.Name + " " + content.Author.Surname
                        };

                        contents.Add(news);
                    }

                    if (content is Models.Tip)
                    {
                        var tip = new IndexViewModel.Tip
                        {
                            Id = content.Id,
                            Title = content.Title,
                            Abstract = content.Abstract,
                            PublishedDate = content.PublishedDate,
                            AuthorId = content.Author.Id,
                            AuthorName = content.Author.Name + " " + content.Author.Surname
                        };

                        contents.Add(tip);
                    }
                }

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
