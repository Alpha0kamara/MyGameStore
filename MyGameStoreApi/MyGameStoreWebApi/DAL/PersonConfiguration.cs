using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGameStoreWebApi.Model;

namespace MyGameStoreWebApi.DAL
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("tblPeople", "Person")
                .HasKey(p => p.Id);

            builder.HasOne(p => p.Store)
                .WithMany(s => s.Persons)
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Email)
                .HasColumnName("EmailAddress")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(p => p.Email)
                .IsUnique();
            
        }
    }
}
