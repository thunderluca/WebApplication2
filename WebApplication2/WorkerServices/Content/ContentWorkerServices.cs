using System.Linq;
using WebApplication2.Models;
using WebApplication2.ViewModels.Content;

namespace WebApplication2.WorkerServices.Content
{
    public class ContentWorkerServices
    {
        public ContentViewModel GetContentViewModel(int id)
        {
            using (var context = new UgiContext())
            {
                var model = (from content in context.Contents
                             where content.Id == id
                             select new ContentViewModel
                             {
                                 Id = content.Id,
                                 Title = content.Title,
                                 Body = content.Body,
                                 AuthorId = content.Author.Id,
                                 AuthorName = content.Author.Name + " " + content.Author.Surname,
                                 PublishedDate = content.PublishedDate,
                                 Tags = content.Tags
                             }).FirstOrDefault();

                if (model == null) return null;

                var articles = (from content in context.Contents
                                where content.Id != id
                                orderby content.PublishedDate descending
                                select new ContentViewModel.Content
                                {
                                    Id = content.Id,
                                    Title = content.Title,
                                    Body = content.Body,
                                    AuthorId = content.Author.Id,
                                    AuthorName = content.Author.Name + " " + content.Author.Surname,
                                    PublishedDate = content.PublishedDate
                                }).ToList().Take(5);

                model.LatestContents = articles;

                return model;
            }
        }

        public ArchiveViewModel GetArticlesArchiveViewModel(int page, int tagId)
        {
            if (page < 0)
                page = 0;

            using (var context = new UgiContext())
            {
                var model = new ArchiveViewModel
                {
                    PageIndex = page,
                    SelectedTagId = tagId
                };

                if (tagId > -1)
                {
                    var selectedTag = (from tag in context.ContentTags
                                       where tag.Id == tagId
                                       select new ArchiveViewModel.ContentTag
                                       {
                                           Id = tag.Id,
                                           Title = tag.Title
                                       }).FirstOrDefault();

                    if (selectedTag != null)
                    {
                        model.SelectedTagId = selectedTag.Id;

                        model.SelectedTagTitle = GlobalWorkerServices.UnescapeTitle(selectedTag.Title);
                    }
                }

                var tags = (from tag in context.ContentTags
                            orderby tag.Title
                            select new ArchiveViewModel.ContentTag
                            {
                                Id = tag.Id,
                                Title = tag.Title
                            }).Take(20).ToList();

                foreach (var tag in tags)
                {
                    tag.UnescapedTitle = GlobalWorkerServices.UnescapeTitle(tag.Title);
                }

                model.Tags = tags;

                var firstQueryable = context.Contents.Where(content => content is Articolo);

                if (tagId > 0)
                    firstQueryable = firstQueryable.Where(content => content.Tags.Any(tag => tag.Id == tagId));

                var count = firstQueryable.Count();

                if (count <= 0)
                {
                    model.Contents = new ArchiveViewModel.Content[] { };
                    model.TotalPageCount = 0;
                }
                else
                {
                    var articles = (from content in firstQueryable
                                    orderby content.PublishedDate descending
                                    select new ArchiveViewModel.Content
                                    {
                                        Id = content.Id,
                                        Title = content.Title,
                                        Body = content.Body,
                                        AuthorId = content.Author.Id,
                                        AuthorName = content.Author.Name + " " + content.Author.Surname,
                                        PublishedDate = content.PublishedDate
                                    }).Skip(page * 10).Take(10).ToList();

                    model.Contents = articles;
                    model.TotalPageCount = (count / 10) + 1;
                }

                return model;
            }
        }

        public ArchiveViewModel GetNewsArchiveViewModel(int page, int tagId)
        {
            if (page < 0)
                page = 0;

            using (var context = new UgiContext())
            {
                var model = new ArchiveViewModel
                {
                    PageIndex = page,
                    SelectedTagId = tagId
                };

                if (tagId > -1)
                {
                    var selectedTag = (from tag in context.ContentTags
                                       where tag.Id == tagId
                                       select new ArchiveViewModel.ContentTag
                                       {
                                           Id = tag.Id,
                                           Title = tag.Title
                                       }).FirstOrDefault();

                    if (selectedTag != null)
                    {
                        model.SelectedTagId = selectedTag.Id;

                        model.SelectedTagTitle = GlobalWorkerServices.UnescapeTitle(selectedTag.Title);
                    }
                }

                var tags = (from tag in context.ContentTags
                            orderby tag.Title
                            select new ArchiveViewModel.ContentTag
                            {
                                Id = tag.Id,
                                Title = tag.Title
                            }).Take(20).ToList();

                foreach (var tag in tags)
                {
                    tag.UnescapedTitle = GlobalWorkerServices.UnescapeTitle(tag.Title);
                }

                model.Tags = tags;

                var firstQueryable = context.Contents.Where(content => content is News);

                if (tagId > 0)
                    firstQueryable = firstQueryable.Where(content => content.Tags.Any(tag => tag.Id == tagId));

                var count = firstQueryable.Count();

                if (count <= 0)
                {
                    model.Contents = new ArchiveViewModel.Content[] { };
                    model.TotalPageCount = 0;
                }
                else
                {
                    var articles = (from content in firstQueryable
                                    orderby content.PublishedDate descending
                                    select new ArchiveViewModel.Content
                                    {
                                        Id = content.Id,
                                        Title = content.Title,
                                        Body = content.Body,
                                        AuthorId = content.Author.Id,
                                        AuthorName = content.Author.Name + " " + content.Author.Surname,
                                        PublishedDate = content.PublishedDate
                                    }).Skip(page * 10).Take(10).ToList();

                    model.Contents = articles;
                    model.TotalPageCount = (count / 10) + 1;
                }

                return model;
            }
        }

        public ArchiveViewModel GetTipsArchiveViewModel(int page, int tagId)
        {
            if (page < 0)
                page = 0;

            using (var context = new UgiContext())
            {
                var model = new ArchiveViewModel
                {
                    PageIndex = page,
                    SelectedTagId = tagId
                };

                if (tagId > -1)
                {
                    var selectedTag = (from tag in context.ContentTags
                                       where tag.Id == tagId
                                       select new ArchiveViewModel.ContentTag
                                       {
                                           Id = tag.Id,
                                           Title = tag.Title
                                       }).FirstOrDefault();

                    if (selectedTag != null)
                    {
                        model.SelectedTagId = selectedTag.Id;

                        model.SelectedTagTitle = GlobalWorkerServices.UnescapeTitle(selectedTag.Title);
                    }
                }

                var tags = (from tag in context.ContentTags
                            orderby tag.Title
                            select new ArchiveViewModel.ContentTag
                            {
                                Id = tag.Id,
                                Title = tag.Title
                            }).Take(20).ToList();

                foreach (var tag in tags)
                {
                    tag.UnescapedTitle = GlobalWorkerServices.UnescapeTitle(tag.Title);
                }

                model.Tags = tags;

                var firstQueryable = context.Contents.Where(content => content is Tip);

                if (tagId > 0)
                    firstQueryable = firstQueryable.Where(content => content.Tags.Any(tag => tag.Id == tagId));

                var count = firstQueryable.Count();

                if (count <= 0)
                {
                    model.Contents = new ArchiveViewModel.Content[] { };
                    model.TotalPageCount = 0;
                }
                else
                {
                    var articles = (from content in firstQueryable
                                    orderby content.PublishedDate descending
                                    select new ArchiveViewModel.Content
                                    {
                                        Id = content.Id,
                                        Title = content.Title,
                                        Body = content.Body,
                                        AuthorId = content.Author.Id,
                                        AuthorName = content.Author.Name + " " + content.Author.Surname,
                                        PublishedDate = content.PublishedDate
                                    }).Skip(page * 10).Take(10).ToList();

                    model.Contents = articles;
                    model.TotalPageCount = (count / 10) + 1;
                }

                return model;
            }
        }
    }
}
