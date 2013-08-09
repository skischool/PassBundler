using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.BundleId).HasColumnName("BundleId");
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            this.HasRequired(t => t.Bundle)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.BundleId);

        }
    }
}