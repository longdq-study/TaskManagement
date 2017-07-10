namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmytask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyTask",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PlanedStartDate = c.DateTime(),
                        PlanedEnDate = c.DateTime(),
                        ActualStartDate = c.DateTime(),
                        ActualEndDate = c.DateTime(),
                        AssigneeID = c.Long(),
                        ReporterID = c.Long(),
                        PercentDone = c.Short(),
                        Status = c.Short(),
                        Attachment = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ModifyBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ModifyBy");
            DropColumn("dbo.AspNetUsers", "ModifyDate");
            DropColumn("dbo.AspNetUsers", "CreateDate");
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropTable("dbo.MyTask");
        }
    }
}
