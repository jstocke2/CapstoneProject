namespace WorkflowRestful.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatever : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Sections", "title", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Sections", "title");
        }
    }
}
