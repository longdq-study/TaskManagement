namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDudateForTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyTask", "CreateDate", c => c.DateTime(precision: 7, storeType: "datetime2", defaultValue: null));
            AddColumn("dbo.MyTask", "DueDate", c => c.DateTime(precision: 7, storeType: "datetime2", defaultValue: null));
            AddColumn("dbo.MyTask", "ModifyDate", c => c.DateTime(precision: 7, storeType: "datetime2", defaultValue: null));
            AddColumn("dbo.MyTask", "PlanedEndDate", c => c.DateTime(precision: 7, storeType: "datetime2", defaultValue: null));
            DropColumn("dbo.MyTask", "PlanedEnDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyTask", "PlanedEnDate", c => c.DateTime(precision: 7, storeType: "datetime2", defaultValue: null));
            DropColumn("dbo.MyTask", "PlanedEndDate");
            DropColumn("dbo.MyTask", "ModifyDate");
            DropColumn("dbo.MyTask", "DueDate");
            DropColumn("dbo.MyTask", "CreateDate");
        }
    }
}
