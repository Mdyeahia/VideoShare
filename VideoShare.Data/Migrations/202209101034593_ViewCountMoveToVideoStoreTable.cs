namespace VideoShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewCountMoveToVideoStoreTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoStores", "ViewCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Video_Detail", "Like", c => c.Boolean());
            AlterColumn("dbo.Video_Detail", "Dislike", c => c.Boolean());
            DropColumn("dbo.Video_Detail", "View");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Video_Detail", "View", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Video_Detail", "Dislike", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Video_Detail", "Like", c => c.Boolean(nullable: false));
            DropColumn("dbo.VideoStores", "ViewCount");
        }
    }
}
