namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Offers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsClientAccepted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Comment");
            DropColumn("dbo.Orders", "IsClientAccepted");
        }
    }
}
