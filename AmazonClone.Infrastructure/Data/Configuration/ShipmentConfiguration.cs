using AmazonClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonClone.Infrastructure.Data.Configuration
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("Shipments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                 .HasDefaultValueSql("getdate()")
                 .IsRequired();

            builder.Property(x => x.Country)
                .IsRequired();

            builder.Property(x => x.EmailAddress)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.HomeAddress)
                .IsRequired();

            builder.Property(x => x.ContactNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.PinCode)
                .HasMaxLength(4)
                .IsRequired();
        }
    }
}
