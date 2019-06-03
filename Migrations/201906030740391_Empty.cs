namespace SAKD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Empty : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Branches(address, name) values(N'Гагарин к-сі, 134', N'№1 филиал')");
            Sql("insert into ComissionTypes(name, SingleTime, DateModified, ComissionPercent) values(N'Көрсетілген қызмет',1,getdate(),7)");
            Sql("insert into services(name, code) values(N'Қардылық қорғау',N'0001')");
            Sql("insert into Citizenships(code, name) values(398, N'Қазақстан Республикасы')");
            Sql("insert into regions(name) values(N'БҚО')");
            Sql("insert into areas(name, RegionId) values(N'Сырым',1)");
            Sql("insert into areas(name, RegionId) values(N'Бөрлі',1)");
            Sql("insert into areas(name, RegionId) values(N'Зеленов',1)");
            Sql("insert into areas(name, RegionId) values(N'Орал қаласы',1)");
            Sql("insert into cities(name, AreaId) values(N'Орал',4)");
            Sql("insert into Industries(Name) values(N'IT технологиялар')");
            Sql("insert into Industries(Name) values(N'Білім беру')");
            Sql("insert into Industries(Name) values(N'Медицина')");
            Sql("insert into Industries(Name) values(N'Әскери')");
        }
        
        public override void Down()
        {
        }
    }
}
