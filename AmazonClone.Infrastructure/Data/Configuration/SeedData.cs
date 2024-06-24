using AmazonClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Infrastructure.Data.Configuration
{
    public static class SeedData
    {
        public static IEnumerable<Category> LoadCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    IconString = "fa-solid fa-tv",
                    HasSize = false
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothing",
                    IconString = "fas fa-tshirt",
                    HasSize = true
                },
                new Category
                {
                    Id = 3,
                    Name = "Books",
                    IconString = "bi bi-book",
                    HasSize = false
                },
                new Category
                {
                    Id = 4,
                    Name = "Home & Kitchen",
                    IconString = "bi bi-house",
                    HasSize = false
                },
                new Category
                {
                    Id = 5,
                    Name = "Sports & Outdoors",
                    IconString = "fa-solid fa-futbol",
                    HasSize = false
                }
            };
        }

        public static IEnumerable<Product> LoadProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Samsung Galaxy S23",
                    Description = "Samsung Galaxy S23 5G Smartphone, 128GB, Phantom Black",
                    ImageUrl = "https://image.samsung.com/au/smartphones/galaxy-s23/buy/s23_pc.png",
                    Price = 799.99,
                    DiscountPercentage = 10,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 2,
                    Name = "Levi's 501 Original Jeans",
                    Description = "Men's Levi's 501 Original Fit Jeans, Medium Stonewash",
                    ImageUrl = "https://cdn.levis.com.au/media/catalog/product/cache/bf9c1236dce8d5003d3a5e90e1989ff1/0/0/005010114-standard-f.jpg",
                    Price = 59.99,
                    DiscountPercentage = 20,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 3,
                    Name = "Atomic Habits",
                    Description = "Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones by James Clear",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/91bYsX41DVL.jpg",
                    Price = 11.99,
                    DiscountPercentage = 15,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 4,
                    Name = "Instant Pot Duo 7-in-1",
                    Description = "Instant Pot Duo 7-in-1 Electric Pressure Cooker, 6 Quart, Stainless Steel",
                    ImageUrl = "https://m.media-amazon.com/images/I/61aTYtlfuyL._AC_SL1500_.jpg",
                    Price = 89.99,
                    DiscountPercentage = 5,
                    CategoryId = 4,
                },
                new Product
                {
                    Id = 5,
                    Name = "Nike Air Zoom Pegasus 39",
                    Description = "Nike Men's Air Zoom Pegasus 39 Running Shoes, White/Black",
                    ImageUrl = "https://images.nike.com/is/image/DotCom/CW7358_100?$SNKRS_COVER_WD$&align=0,1",
                    Price = 119.99,
                    DiscountPercentage = 12,
                    CategoryId = 5,
                }
            };

        }
    }
}
