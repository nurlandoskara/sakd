namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employments", "IndustryId", "dbo.Industries");
            DropIndex("dbo.Employments", new[] { "IndustryId" });
            AlterColumn("dbo.Employments", "IndustryId", c => c.Int());
            CreateIndex("dbo.Employments", "IndustryId");
            AddForeignKey("dbo.Employments", "IndustryId", "dbo.Industries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employments", "IndustryId", "dbo.Industries");
            DropIndex("dbo.Employments", new[] { "IndustryId" });
            AlterColumn("dbo.Employments", "IndustryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employments", "IndustryId");
            AddForeignKey("dbo.Employments", "IndustryId", "dbo.Industries", "Id", cascadeDelete: true);
        }
    }
}
