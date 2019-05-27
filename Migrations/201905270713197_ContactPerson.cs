namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactPersons", "RelationType", c => c.Int(nullable: false));
            DropColumn("dbo.ContactPersons", "RelationStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactPersons", "RelationStatus", c => c.Int(nullable: false));
            DropColumn("dbo.ContactPersons", "RelationType");
        }
    }
}
