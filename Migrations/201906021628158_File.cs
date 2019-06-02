namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class File : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Files", "Type", c => c.String());
            AddColumn("dbo.Files", "Code", c => c.String());
            AlterColumn("dbo.Files", "FileType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Files", "FileType", c => c.Int(nullable: false));
            DropColumn("dbo.Files", "Code");
            DropColumn("dbo.Files", "Type");
            DropColumn("dbo.Files", "Date");
        }
    }
}
