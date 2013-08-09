using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Models.Mapping
{
    public class ClientBundleMap : EntityTypeConfiguration<ClientBundle>
    {
        public ClientBundleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ClientBundles");
            this.Property(t => t.BundleId).HasColumnName("BundleId");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            //this.HasRequired(t => t.Bundle)
                //.WithMany(t => t.ClientBundles)
                //.HasForeignKey(d => d.BundleId);
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ClientBundles)
                .HasForeignKey(d => d.ClientId);

        }
    }
}
