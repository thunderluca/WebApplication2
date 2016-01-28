using System.Data.Entity;

namespace WebApplication2.Models
{
    public class UgiContext : DbContext
    {
        public UgiContext () : base("DefaultConnection") { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Content> Contents { get; set; }

        public DbSet<ContentTag> ContentTags { get; set; }

        public DbSet<MediaPost> MediaPosts { get; set; }

        public DbSet<MediaAlbum> MediaAlbums { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<ForumReply> ForumReplies { get; set; }

        public DbSet<ForumGroup> ForumGroups { get; set; }

        public DbSet<BlogPost> Blogs { get; set; }
    }
}