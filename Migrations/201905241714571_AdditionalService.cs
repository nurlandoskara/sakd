namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Code");
        }
    }
}
