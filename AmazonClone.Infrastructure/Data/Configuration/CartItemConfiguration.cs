using AmazonClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonClone.Infrastructure.Data.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Cart)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Cart)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasMaxLength(100)
                .HasDefaultValue(1)
                .IsRequired();
        }
    }
}
