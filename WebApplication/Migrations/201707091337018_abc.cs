namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropColumn("dbo.AspNetUsers", "CreateDate");
            DropColumn("dbo.AspNetUsers", "ModifyDate");
            DropColumn("dbo.AspNetUsers", "ModifyBy");
            DropTable("dbo.MyTask");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.AspNetUsers", "ModifyBy", c => c.String());
            AddColumn("dbo.AspNetUsers", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String());
        }
    }
}
