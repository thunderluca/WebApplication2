using System.Linq;
using WebApplication2.Models;
using WebApplication2.ViewModels.Forum;

namespace WebApplication2.WorkerServices.Forum
{
    public class ForumWorkerServices
    {
        public ThreadViewModel GetThreadModel(int id, int page = 1)
        {
            using (var context = new UgiContext())
            {
                var model = (from thread in context.Threads
                    where thread.Id == id
                    select new ThreadViewModel
                    {
                        Id = thread.Id,
                        Title = thread.Title,
                        AuthorId = thread.Author.Id,
                        AuthorName = thread.Author.Name + " " + thread.Author.Surname,
                        PublishedDate = thread.PublishedDate,
                        ModifiedDate = thread.ModifiedDate
                    }).FirstOrDefault();

                if (model == null) return null;

                var replies = (from reply in context.ForumReplies
                    orderby reply.PublishedDate ascending
                    where reply.Thread.Id == id
                    select new ThreadViewModel.ForumReply
                    {
                        Id = reply.Id,
                        AuthorName = reply.Author.Name + " " + reply.Author.Surname,
                        Body = reply.Body,
                        ThreadId = id,
                        PublishedDate = reply.PublishedDate,
                        ModifiedDate = reply.ModifiedDate,
                        ParentId = reply.Parent.Id,
                        ParentAuthorName = reply.Parent.Author.Name + " " + reply.Parent.Author.Surname
                    }).Skip(page*10).ToList();

                model.Replies = replies;

                return model;
            }
        }
    }
}
