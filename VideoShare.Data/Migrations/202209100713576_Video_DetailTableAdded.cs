namespace VideoShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Video_DetailTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Video_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        VideoId = c.Int(nullable: false),
                        Like = c.Boolean(nullable: false),
                        Dislike = c.Boolean(nullable: false),
                        View = c.Boolean(nullable: false),
                        VideoStore_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.VideoStores", t => t.VideoStore_Id)
                .Index(t => t.UserId)
                .Index(t => t.VideoStore_Id);
            
            DropColumn("dbo.VideoStores", "Like_count");
            DropColumn("dbo.VideoStores", "Dislike_count");
            DropColumn("dbo.VideoStores", "View_count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VideoStores", "View_count", c => c.Int(nullable: false));
            AddColumn("dbo.VideoStores", "Dislike_count", c => c.Int(nullable: false));
            AddColumn("dbo.VideoStores", "Like_count", c => c.Int(nullable: false));
            DropForeignKey("dbo.Video_Detail", "VideoStore_Id", "dbo.VideoStores");
            DropForeignKey("dbo.Video_Detail", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Video_Detail", new[] { "VideoStore_Id" });
            DropIndex("dbo.Video_Detail", new[] { "UserId" });
            DropTable("dbo.Video_Detail");
        }
    }
}
