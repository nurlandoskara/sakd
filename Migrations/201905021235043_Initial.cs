namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SourceInfo = c.Int(nullable: false),
                        IsAlcohol = c.Boolean(nullable: false),
                        IsAnotherPerson = c.Boolean(nullable: false),
                        IsInadequate = c.Boolean(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdditionalServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Percent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Product = c.Int(nullable: false),
                        Program = c.Int(nullable: false),
                        Method = c.Int(nullable: false),
                        Purpose = c.Int(nullable: false),
                        Months = c.Int(nullable: false),
                        RequestSum = c.Int(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PatronymicName = c.String(),
                        Iin = c.String(),
                        CitizenshipId = c.Int(nullable: false),
                        BirthPlace = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        IsNameChanged = c.Boolean(nullable: false),
                        Education = c.String(),
                        IsMilitaryOrPension = c.Boolean(nullable: false),
                        SocialStatusId = c.Int(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        IsLivingAddressRegistration = c.Boolean(nullable: false),
                        RegistrationAddressId = c.Int(nullable: false),
                        LivingAddressId = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        HomePhone = c.String(),
                        Email = c.String(),
                        SmsCode = c.String(),
                        ContactPersonId = c.Int(nullable: false),
                        FamilyId = c.Int(nullable: false),
                        ParentsId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        AdditionalInfoId = c.Int(nullable: false),
                        IsFatca = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdditionalInfoes", t => t.AdditionalInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Citizenships", t => t.CitizenshipId, cascadeDelete: true)
                .ForeignKey("dbo.ContactPersons", t => t.ContactPersonId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .ForeignKey("dbo.Families", t => t.FamilyId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.LivingAddressId, cascadeDelete: false)
                .ForeignKey("dbo.Parents", t => t.ParentsId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.RegistrationAddressId, cascadeDelete: false)
                .ForeignKey("dbo.SocialStatus", t => t.SocialStatusId, cascadeDelete: true)
                .Index(t => t.CitizenshipId)
                .Index(t => t.SocialStatusId)
                .Index(t => t.DocumentId)
                .Index(t => t.RegistrationAddressId)
                .Index(t => t.LivingAddressId)
                .Index(t => t.ContactPersonId)
                .Index(t => t.FamilyId)
                .Index(t => t.ParentsId)
                .Index(t => t.JobId)
                .Index(t => t.AdditionalInfoId);
            
            CreateTable(
                "dbo.Citizenships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationStatus = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PatronymicName = c.String(),
                        MobilePhone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Number = c.String(),
                        Organization = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamilyStatus = c.Int(nullable: false),
                        DependantsCount = c.Int(nullable: false),
                        HasRealProperty = c.Boolean(nullable: false),
                        HasMovableProperty = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainSalary = c.Double(nullable: false),
                        AdditionalSalary = c.Double(nullable: false),
                        WorkExperience = c.Int(nullable: false),
                        SalaryBank = c.String(),
                        AdditionalJob_Id = c.Int(),
                        MainJob_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employments", t => t.AdditionalJob_Id)
                .ForeignKey("dbo.Employments", t => t.MainJob_Id)
                .Index(t => t.AdditionalJob_Id)
                .Index(t => t.MainJob_Id);
            
            CreateTable(
                "dbo.Employments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndustryId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        Phone = c.String(),
                        PositionCategory = c.String(),
                        WorkExperience = c.Int(nullable: false),
                        CompanyEmployeesCount = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Industries", t => t.IndustryId, cascadeDelete: true)
                .Index(t => t.IndustryId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Street = c.String(),
                        House = c.String(),
                        Block = c.String(),
                        Building = c.String(),
                        Apartment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId)
                .Index(t => t.AreaId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: false)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: false)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentsStatus = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PatronymicName = c.String(),
                        LivingAddressId = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        HomePhone = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.LivingAddressId, cascadeDelete: true)
                .Index(t => t.LivingAddressId);
            
            CreateTable(
                "dbo.SocialStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Path = c.String(),
                        FileType = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdditionalServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Files", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "SocialStatusId", "dbo.SocialStatus");
            DropForeignKey("dbo.Clients", "RegistrationAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "ParentsId", "dbo.Parents");
            DropForeignKey("dbo.Parents", "LivingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "LivingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "MainJob_Id", "dbo.Employments");
            DropForeignKey("dbo.Jobs", "AdditionalJob_Id", "dbo.Employments");
            DropForeignKey("dbo.Employments", "IndustryId", "dbo.Industries");
            DropForeignKey("dbo.Employments", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Addresses", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Areas", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Clients", "FamilyId", "dbo.Families");
            DropForeignKey("dbo.Clients", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Clients", "ContactPersonId", "dbo.ContactPersons");
            DropForeignKey("dbo.Clients", "CitizenshipId", "dbo.Citizenships");
            DropForeignKey("dbo.Clients", "AdditionalInfoId", "dbo.AdditionalInfoes");
            DropForeignKey("dbo.Orders", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.AdditionalServices", "OrderId", "dbo.Orders");
            DropIndex("dbo.Files", new[] { "OrderId" });
            DropIndex("dbo.Parents", new[] { "LivingAddressId" });
            DropIndex("dbo.Cities", new[] { "AreaId" });
            DropIndex("dbo.Areas", new[] { "RegionId" });
            DropIndex("dbo.Addresses", new[] { "CityId" });
            DropIndex("dbo.Addresses", new[] { "AreaId" });
            DropIndex("dbo.Addresses", new[] { "RegionId" });
            DropIndex("dbo.Employments", new[] { "AddressId" });
            DropIndex("dbo.Employments", new[] { "IndustryId" });
            DropIndex("dbo.Jobs", new[] { "MainJob_Id" });
            DropIndex("dbo.Jobs", new[] { "AdditionalJob_Id" });
            DropIndex("dbo.Clients", new[] { "AdditionalInfoId" });
            DropIndex("dbo.Clients", new[] { "JobId" });
            DropIndex("dbo.Clients", new[] { "ParentsId" });
            DropIndex("dbo.Clients", new[] { "FamilyId" });
            DropIndex("dbo.Clients", new[] { "ContactPersonId" });
            DropIndex("dbo.Clients", new[] { "LivingAddressId" });
            DropIndex("dbo.Clients", new[] { "RegistrationAddressId" });
            DropIndex("dbo.Clients", new[] { "DocumentId" });
            DropIndex("dbo.Clients", new[] { "SocialStatusId" });
            DropIndex("dbo.Clients", new[] { "CitizenshipId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.Orders", new[] { "BranchId" });
            DropIndex("dbo.AdditionalServices", new[] { "ServiceId" });
            DropIndex("dbo.AdditionalServices", new[] { "OrderId" });
            DropTable("dbo.Users");
            DropTable("dbo.Services");
            DropTable("dbo.Files");
            DropTable("dbo.SocialStatus");
            DropTable("dbo.Parents");
            DropTable("dbo.Industries");
            DropTable("dbo.Cities");
            DropTable("dbo.Regions");
            DropTable("dbo.Areas");
            DropTable("dbo.Addresses");
            DropTable("dbo.Employments");
            DropTable("dbo.Jobs");
            DropTable("dbo.Families");
            DropTable("dbo.Documents");
            DropTable("dbo.ContactPersons");
            DropTable("dbo.Citizenships");
            DropTable("dbo.Clients");
            DropTable("dbo.Branches");
            DropTable("dbo.Orders");
            DropTable("dbo.AdditionalServices");
            DropTable("dbo.AdditionalInfoes");
        }
    }
}
