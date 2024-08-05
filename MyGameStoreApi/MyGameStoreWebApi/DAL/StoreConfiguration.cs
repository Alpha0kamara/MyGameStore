using Microsoft.EntityFrameworkCore;
using MyGameStoreWebApi.Model;

namespace MyGameStoreWebApi.DAL
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("tblStores", "Store")
                .HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(s => s.Name)
                .IsUnique();

            builder.Property(s=>s.Street)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(s => s.Number)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(s => s.Addition)
                .HasMaxLength(2);

            builder.Property(s => s.Zipcode)
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(s => s.City)
                .HasMaxLength(60)
                .HasColumnName("Place");

        }
    }
}
