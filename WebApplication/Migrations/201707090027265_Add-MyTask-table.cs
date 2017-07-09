namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyTasktable : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyTask");
        }
    }
}
