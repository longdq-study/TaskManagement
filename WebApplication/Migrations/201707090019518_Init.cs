namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
