using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Domain.MainModule.Entities;
using Infrastructure.Data.MainModule.Models;
using Infrastructure.Data.MainModule.Models.Mapping;

namespace Infrastructure.Data.MainModule.Contexts
{
    public partial class PassBundlerContext : DbContext
    {
        static PassBundlerContext()
        {
            Database.SetInitializer<PassBundlerContext>(null);
        }

        public PassBundlerContext()
            : base("Name=PassBundlerContext")
        {
        }

        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<ClientBundle> ClientBundles { get; set; }
        public DbSet<ClientProduct> ClientProducts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BundleMap());
            modelBuilder.Configurations.Add(new ClientBundleMap());
            modelBuilder.Configurations.Add(new ClientProductMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
