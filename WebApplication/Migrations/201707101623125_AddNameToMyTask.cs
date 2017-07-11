namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMyTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyTask", "TaskName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyTask", "TaskName");
        }
    }
}
