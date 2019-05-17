namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientNullables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "CitizenshipId", "dbo.Citizenships");
            DropForeignKey("dbo.Clients", "ContactPersonId", "dbo.ContactPersons");
            DropForeignKey("dbo.Clients", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Clients", "FamilyId", "dbo.Families");
            DropForeignKey("dbo.Clients", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Clients", "LivingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "ParentsId", "dbo.Parents");
            DropForeignKey("dbo.Clients", "RegistrationAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "SocialStatusId", "dbo.SocialStatus");
            DropIndex("dbo.Clients", new[] { "CitizenshipId" });
            DropIndex("dbo.Clients", new[] { "SocialStatusId" });
            DropIndex("dbo.Clients", new[] { "DocumentId" });
            DropIndex("dbo.Clients", new[] { "RegistrationAddressId" });
            DropIndex("dbo.Clients", new[] { "LivingAddressId" });
            DropIndex("dbo.Clients", new[] { "ContactPersonId" });
            DropIndex("dbo.Clients", new[] { "FamilyId" });
            DropIndex("dbo.Clients", new[] { "ParentsId" });
            DropIndex("dbo.Clients", new[] { "JobId" });
            AlterColumn("dbo.Clients", "CitizenshipId", c => c.Int());
            AlterColumn("dbo.Clients", "SocialStatusId", c => c.Int());
            AlterColumn("dbo.Clients", "DocumentId", c => c.Int());
            AlterColumn("dbo.Clients", "RegistrationAddressId", c => c.Int());
            AlterColumn("dbo.Clients", "LivingAddressId", c => c.Int());
            AlterColumn("dbo.Clients", "ContactPersonId", c => c.Int());
            AlterColumn("dbo.Clients", "FamilyId", c => c.Int());
            AlterColumn("dbo.Clients", "ParentsId", c => c.Int());
            AlterColumn("dbo.Clients", "JobId", c => c.Int());
            CreateIndex("dbo.Clients", "CitizenshipId");
            CreateIndex("dbo.Clients", "SocialStatusId");
            CreateIndex("dbo.Clients", "DocumentId");
            CreateIndex("dbo.Clients", "RegistrationAddressId");
            CreateIndex("dbo.Clients", "LivingAddressId");
            CreateIndex("dbo.Clients", "ContactPersonId");
            CreateIndex("dbo.Clients", "FamilyId");
            CreateIndex("dbo.Clients", "ParentsId");
            CreateIndex("dbo.Clients", "JobId");
            AddForeignKey("dbo.Clients", "CitizenshipId", "dbo.Citizenships", "Id");
            AddForeignKey("dbo.Clients", "ContactPersonId", "dbo.ContactPersons", "Id");
            AddForeignKey("dbo.Clients", "DocumentId", "dbo.Documents", "Id");
            AddForeignKey("dbo.Clients", "FamilyId", "dbo.Families", "Id");
            AddForeignKey("dbo.Clients", "JobId", "dbo.Jobs", "Id");
            AddForeignKey("dbo.Clients", "LivingAddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Clients", "ParentsId", "dbo.Parents", "Id");
            AddForeignKey("dbo.Clients", "RegistrationAddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Clients", "SocialStatusId", "dbo.SocialStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "SocialStatusId", "dbo.SocialStatus");
            DropForeignKey("dbo.Clients", "RegistrationAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "ParentsId", "dbo.Parents");
            DropForeignKey("dbo.Clients", "LivingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Clients", "FamilyId", "dbo.Families");
            DropForeignKey("dbo.Clients", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Clients", "ContactPersonId", "dbo.ContactPersons");
            DropForeignKey("dbo.Clients", "CitizenshipId", "dbo.Citizenships");
            DropIndex("dbo.Clients", new[] { "JobId" });
            DropIndex("dbo.Clients", new[] { "ParentsId" });
            DropIndex("dbo.Clients", new[] { "FamilyId" });
            DropIndex("dbo.Clients", new[] { "ContactPersonId" });
            DropIndex("dbo.Clients", new[] { "LivingAddressId" });
            DropIndex("dbo.Clients", new[] { "RegistrationAddressId" });
            DropIndex("dbo.Clients", new[] { "DocumentId" });
            DropIndex("dbo.Clients", new[] { "SocialStatusId" });
            DropIndex("dbo.Clients", new[] { "CitizenshipId" });
            AlterColumn("dbo.Clients", "JobId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "ParentsId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "FamilyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "ContactPersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "LivingAddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "RegistrationAddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "DocumentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "SocialStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "CitizenshipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "JobId");
            CreateIndex("dbo.Clients", "ParentsId");
            CreateIndex("dbo.Clients", "FamilyId");
            CreateIndex("dbo.Clients", "ContactPersonId");
            CreateIndex("dbo.Clients", "LivingAddressId");
            CreateIndex("dbo.Clients", "RegistrationAddressId");
            CreateIndex("dbo.Clients", "DocumentId");
            CreateIndex("dbo.Clients", "SocialStatusId");
            CreateIndex("dbo.Clients", "CitizenshipId");
            AddForeignKey("dbo.Clients", "SocialStatusId", "dbo.SocialStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "RegistrationAddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "ParentsId", "dbo.Parents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "LivingAddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "FamilyId", "dbo.Families", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "ContactPersonId", "dbo.ContactPersons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "CitizenshipId", "dbo.Citizenships", "Id", cascadeDelete: true);
        }
    }
}
