namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BranchName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "Name", c => c.String());
            DropColumn("dbo.Branches", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Branches", "Number", c => c.Int(nullable: false));
            DropColumn("dbo.Branches", "Name");
        }
    }
}
