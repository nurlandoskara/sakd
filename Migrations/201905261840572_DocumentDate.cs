namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "Date", c => c.DateTime());
            AlterColumn("dbo.Documents", "DateEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "DateEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "Date", c => c.DateTime(nullable: false));
        }
    }
}
