using AmazonClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonClone.Infrastructure.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.CreatedAt)
                 .HasDefaultValueSql("getdate()")
                 .IsRequired();

            builder.Property(x => x.TotalPrice)
                .IsRequired();


            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);


            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);


            builder.HasOne(x => x.Payment)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.PaymentId);


            builder.HasOne(x => x.Shipment)
               .WithOne(x => x.Order)
               .HasForeignKey<Order>(x => x.ShipmentId);


        }
    }
}
