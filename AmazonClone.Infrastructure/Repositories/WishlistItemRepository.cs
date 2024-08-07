﻿using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace AmazonClone.Infrastructure.Repositories
{
    public class WishlistItemRepository : GenericRepository<WishlistItem>, IWishlistRepository
    {
        private readonly AppDbContext _db;

        public WishlistItemRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetCustomerWishlist(string userId)
        {
            var productIds = _db.Wishlist.Where(x => x.UserId == userId).Select(x => x.ProductId);
            var result = _db.Products.Include(x => x.Category).Where(x => productIds.Contains(x.Id));
            var queryString = result.ToQueryString();
            return result.ToList();
        }


        public int GetCustomerWishlistSize(string userId)
        {
            return _db.Wishlist.Count(w => w.UserId == userId);
        }


        public bool IsProductInCustomerWishlist(string userId, int productId)
        {
            return _db.Wishlist.Any(x => x.ProductId == productId && x.UserId == userId);
        }


    }
}
