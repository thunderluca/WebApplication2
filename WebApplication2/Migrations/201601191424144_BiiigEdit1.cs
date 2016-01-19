namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BiiigEdit1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        PublishedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Authors", "MediaPost_Id", c => c.Int());
            AddColumn("dbo.ContentTags", "MediaPost_Id", c => c.Int());
            AddColumn("dbo.MediaPosts", "VideoUrl", c => c.String(nullable: false));
            AddColumn("dbo.MediaPosts", "PublishedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MediaPosts", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MediaPosts", "Album_Id", c => c.Int());
            CreateIndex("dbo.Authors", "MediaPost_Id");
            CreateIndex("dbo.ContentTags", "MediaPost_Id");
            CreateIndex("dbo.MediaPosts", "Album_Id");
            AddForeignKey("dbo.MediaPosts", "Album_Id", "dbo.MediaAlbums", "Id");
            AddForeignKey("dbo.Authors", "MediaPost_Id", "dbo.MediaPosts", "Id");
            AddForeignKey("dbo.ContentTags", "MediaPost_Id", "dbo.MediaPosts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentTags", "MediaPost_Id", "dbo.MediaPosts");
            DropForeignKey("dbo.Authors", "MediaPost_Id", "dbo.MediaPosts");
            DropForeignKey("dbo.MediaPosts", "Album_Id", "dbo.MediaAlbums");
            DropIndex("dbo.MediaPosts", new[] { "Album_Id" });
            DropIndex("dbo.ContentTags", new[] { "MediaPost_Id" });
            DropIndex("dbo.Authors", new[] { "MediaPost_Id" });
            DropColumn("dbo.MediaPosts", "Album_Id");
            DropColumn("dbo.MediaPosts", "ModifiedDate");
            DropColumn("dbo.MediaPosts", "PublishedDate");
            DropColumn("dbo.MediaPosts", "VideoUrl");
            DropColumn("dbo.ContentTags", "MediaPost_Id");
            DropColumn("dbo.Authors", "MediaPost_Id");
            DropTable("dbo.MediaAlbums");
        }
    }
}
