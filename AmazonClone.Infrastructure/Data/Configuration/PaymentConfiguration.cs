using AmazonClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonClone.Infrastructure.Data.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                 .HasDefaultValueSql("getdate()")
                 .IsRequired();

            builder.Property(x => x.PaymentMethod)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();
        }
    }
}
