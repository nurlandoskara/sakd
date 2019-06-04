namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "MonthlyDate", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "IsVisaInstant", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Pan", c => c.String());
            AddColumn("dbo.Orders", "CodeWord", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CodeWord");
            DropColumn("dbo.Orders", "Pan");
            DropColumn("dbo.Orders", "IsVisaInstant");
            DropColumn("dbo.Orders", "MonthlyDate");
        }
    }
}
