namespace VideoShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewCountMoveToVideoStoreTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Video_Detail", "VideoStore_Id", "dbo.VideoStores");
            DropIndex("dbo.Video_Detail", new[] { "VideoStore_Id" });
            RenameColumn(table: "dbo.Video_Detail", name: "VideoStore_Id", newName: "VideoStoreId");
            AlterColumn("dbo.Video_Detail", "VideoStoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Video_Detail", "VideoStoreId");
            AddForeignKey("dbo.Video_Detail", "VideoStoreId", "dbo.VideoStores", "Id", cascadeDelete: true);
            DropColumn("dbo.Video_Detail", "VideoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Video_Detail", "VideoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Video_Detail", "VideoStoreId", "dbo.VideoStores");
            DropIndex("dbo.Video_Detail", new[] { "VideoStoreId" });
            AlterColumn("dbo.Video_Detail", "VideoStoreId", c => c.Int());
            RenameColumn(table: "dbo.Video_Detail", name: "VideoStoreId", newName: "VideoStore_Id");
            CreateIndex("dbo.Video_Detail", "VideoStore_Id");
            AddForeignKey("dbo.Video_Detail", "VideoStore_Id", "dbo.VideoStores", "Id");
        }
    }
}
