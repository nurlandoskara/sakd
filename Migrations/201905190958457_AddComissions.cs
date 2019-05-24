namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComissions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ComissionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComissionTypes", t => t.ComissionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ComissionTypeId);
            
            CreateTable(
                "dbo.ComissionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SingleTime = c.Boolean(nullable: false),
                        Percent = c.Double(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comissions", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Comissions", "ComissionTypeId", "dbo.ComissionTypes");
            DropIndex("dbo.Comissions", new[] { "ComissionTypeId" });
            DropIndex("dbo.Comissions", new[] { "OrderId" });
            DropTable("dbo.ComissionTypes");
            DropTable("dbo.Comissions");
        }
    }
}
