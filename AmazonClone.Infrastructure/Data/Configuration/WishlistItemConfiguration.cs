using AmazonClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonClone.Infrastructure.Data.Configuration
{
    public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
    {
        public void Configure(EntityTypeBuilder<WishlistItem> builder)
        {
            builder.ToTable("WishlistItems");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Wishlist)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Wishlist)
                .HasForeignKey(x => x.ProductId);

        }
    }
}
