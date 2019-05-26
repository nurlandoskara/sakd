namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "RegionId", "dbo.Regions");
            DropIndex("dbo.Addresses", new[] { "RegionId" });
            DropIndex("dbo.Addresses", new[] { "AreaId" });
            DropIndex("dbo.Addresses", new[] { "CityId" });
            AlterColumn("dbo.Addresses", "RegionId", c => c.Int());
            AlterColumn("dbo.Addresses", "AreaId", c => c.Int());
            AlterColumn("dbo.Addresses", "CityId", c => c.Int());
            CreateIndex("dbo.Addresses", "RegionId");
            CreateIndex("dbo.Addresses", "AreaId");
            CreateIndex("dbo.Addresses", "CityId");
            AddForeignKey("dbo.Addresses", "AreaId", "dbo.Areas", "Id");
            AddForeignKey("dbo.Addresses", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Addresses", "RegionId", "dbo.Regions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "AreaId", "dbo.Areas");
            DropIndex("dbo.Addresses", new[] { "CityId" });
            DropIndex("dbo.Addresses", new[] { "AreaId" });
            DropIndex("dbo.Addresses", new[] { "RegionId" });
            AlterColumn("dbo.Addresses", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "AreaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "RegionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "CityId");
            CreateIndex("dbo.Addresses", "AreaId");
            CreateIndex("dbo.Addresses", "RegionId");
            AddForeignKey("dbo.Addresses", "RegionId", "dbo.Regions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
        }
    }
}
