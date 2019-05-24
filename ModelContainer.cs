using SAKD.Models;

namespace SAKD
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContainer : DbContext
    {
        // Your context has been configured to use a 'ModelContainer' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SAKD.ModelContainer' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelContainer' 
        // connection string in the application configuration file.
        public ModelContainer()
            : base("name=ModelContainer")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<AdditionalInfo> AdditionalInfos { get; set; }
        public virtual DbSet<AdditionalService> AdditionalServices { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Citizenship> Citizenships { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ContactPerson> ContactPersons { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Employment> Employments { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Parents> Parentses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<SocialStatus> SocialStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ComissionType> ComissionTypes { get; set; }
        public virtual DbSet<Comission> Comissions { get; set; }
    }
}