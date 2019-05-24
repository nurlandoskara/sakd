namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComissionPercent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComissionTypes", "ComissionPercent", c => c.Double(nullable: false));
            DropColumn("dbo.ComissionTypes", "Percent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComissionTypes", "Percent", c => c.Double(nullable: false));
            DropColumn("dbo.ComissionTypes", "ComissionPercent");
        }
    }
}
