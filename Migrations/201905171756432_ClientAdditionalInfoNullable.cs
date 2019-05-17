namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientAdditionalInfoNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "AdditionalInfoId", "dbo.AdditionalInfoes");
            DropIndex("dbo.Clients", new[] { "AdditionalInfoId" });
            AlterColumn("dbo.Clients", "AdditionalInfoId", c => c.Int());
            CreateIndex("dbo.Clients", "AdditionalInfoId");
            AddForeignKey("dbo.Clients", "AdditionalInfoId", "dbo.AdditionalInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "AdditionalInfoId", "dbo.AdditionalInfoes");
            DropIndex("dbo.Clients", new[] { "AdditionalInfoId" });
            AlterColumn("dbo.Clients", "AdditionalInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "AdditionalInfoId");
            AddForeignKey("dbo.Clients", "AdditionalInfoId", "dbo.AdditionalInfoes", "Id", cascadeDelete: true);
        }
    }
}
