namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToMyTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyTask", "Description", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyTask", "Description");
        }
    }
}
