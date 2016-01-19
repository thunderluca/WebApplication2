namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BiiigEdit2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "TwitterAccount", c => c.String());
            DropColumn("dbo.Authors", "TwitterSite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "TwitterSite", c => c.String());
            DropColumn("dbo.Authors", "TwitterAccount");
        }
    }
}
