namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTaskRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyTask", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.MyTask", "ApplicationUser_Id");
            AddForeignKey("dbo.MyTask", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyTask", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MyTask", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.MyTask", "ApplicationUser_Id");
        }
    }
}
