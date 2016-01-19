﻿using System.Linq;
using WebApplication2.Models;
using WebApplication2.ViewModels.Autore;

namespace WebApplication2.WorkerServices.Autore
{
    public class AutoreWorkerServices
    {
        public static AutoreViewModel GetAutoreViewModel(int id)
        {
            using (var context = new UgiContext())
            {
                var model = (from author in context.Authors
                    where author.Id == id
                    select new AutoreViewModel
                    {
                        AuthorId = author.Id,
                        AuthorName = author.Name + " " + author.Surname,
                        RegistrationDate = author.RegistrationDate,
                        RawBiography = author.Biography,
                        BlogSite = author.BlogSite ?? string.Empty,
                        FacebookSite = author.FacebookSite ?? string.Empty,
                        GooglePlusSite = author.GooglePlusSite ?? string.Empty,
                        TwitterAccount = author.TwitterAccount ?? string.Empty
                    }).FirstOrDefault();

                if (model == null) return null;

                var authorContentsQueryable = from content in context.Contents
                    where content.Author.Id == id
                    select content;

                var articlesCount = authorContentsQueryable.Count(content => content.Section.Id == 1);

                var newsCount = authorContentsQueryable.Count(content => content.Section.Id == 2);

                var tipsCount = authorContentsQueryable.Count(content => content.Section.Id == 3);

                var repliesCount = (from reply in context.ForumReplies
                    where reply.Author.Id == id
                    select reply).Count();

                var contents = (from content in authorContentsQueryable
                    select new AutoreViewModel.Content
                    {
                        Id = content.Id,
                        Title = content.Title,
                        SectionTitle = content.Section.Title,
                        PublishedDate = content.PublishedDate
                    }).Take(10).ToList();

                model.LatestContents = contents;
                model.ArticlesCount = articlesCount;
                model.NewsCount = newsCount;
                model.TipsCount = tipsCount;
                model.ForumRepliesCount = repliesCount;

                return model;
            }
        }
    }
}