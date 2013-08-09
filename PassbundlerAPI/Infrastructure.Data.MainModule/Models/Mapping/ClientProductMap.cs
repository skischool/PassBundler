using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Models.Mapping
{
    public class ClientProductMap : EntityTypeConfiguration<ClientProduct>
    {
        public ClientProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ClientProducts");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ClientProducts)
                .HasForeignKey(d => d.ClientId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ClientProducts)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
