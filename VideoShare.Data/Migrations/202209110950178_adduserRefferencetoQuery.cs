namespace VideoShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserRefferencetoQuery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Video_Detail_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Video_Detail_Id");
            AddForeignKey("dbo.AspNetUsers", "Video_Detail_Id", "dbo.Video_Detail", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Video_Detail_Id", "dbo.Video_Detail");
            DropIndex("dbo.AspNetUsers", new[] { "Video_Detail_Id" });
            DropColumn("dbo.AspNetUsers", "Video_Detail_Id");
        }
    }
}
