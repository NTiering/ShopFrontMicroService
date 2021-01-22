using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ShopFront.Inventory.DataModels
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=shopfront.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .HasData(
                        new Category { CategoryId = 1, Name = "Mens", Description = "Mens T-Shirts" },
                        new Category { CategoryId = 2, Name = "Womens", Description = "Womens T-Shirts" },
                        new Category { CategoryId = 3, Name = "Kids", Description = "Kids T-Shirts" },
                        new Category { CategoryId = 4, Name = "Sale", Description = "Upto 30% off" },
                        new Category { CategoryId = 5, Name = "10% off", Description = "Up to 10% off", ParentCategoryId = 4 },
                        new Category { CategoryId = 6, Name = "20% off", Description = "Up to 20% off", ParentCategoryId = 4 },
                        new Category { CategoryId = 7, Name = "30% off", Description = "Up to 30% off", ParentCategoryId = 4 }
            );
        }
    }

    public class TempDataContext : IDisposable
    {
        public TempDataContext()
        {
            Category.AddRange(new[]
            {
                        new Category { CategoryId = 1, Name = "Mens", Description = "Mens T-Shirts" },
                        new Category { CategoryId = 2, Name = "Womens", Description = "Womens T-Shirts" },
                        new Category { CategoryId = 3, Name = "Kids", Description = "Kids T-Shirts" },
                        new Category { CategoryId = 4, Name = "Sale", Description = "Upto 30% off" },

                        new Category { CategoryId = 5, Name = "Summer T-shirts", Description = "Mens T-Shirts for summer" , ParentCategoryId = 1},
                        new Category { CategoryId = 6, Name = "Winter T-shirts", Description = "Mens T-Shirts for winter" , ParentCategoryId = 1},

                        new Category { CategoryId = 7, Name = "Fun T-shirts", Description = "Womens funny T-shirts" , ParentCategoryId = 2},
                        new Category { CategoryId = 8, Name = "Long Sleeved T-shirts", Description = "Long sleeved T-shirts" , ParentCategoryId = 2},

                        new Category { CategoryId = 9, Name = "Boys T-shirts", Description = "T-shirts for girls" , ParentCategoryId = 3},
                        new Category { CategoryId = 10, Name = "Girls T-shirts", Description = "T-shirts for boys" , ParentCategoryId = 3},

                        new Category { CategoryId = 11, Name = "30% off", Description = "T-shirts at 30% reduction" , ParentCategoryId = 4},
                        new Category { CategoryId = 12, Name = "10% off", Description = "T-shirts at 10% reduction" , ParentCategoryId = 4}
            });

            // add 25 products to each category

            var description = new[]
            {
                "Unicon",
                "Badger",
                "TARDIS",
                "Puppy dog",
                "Purple square",
                "Mike Oldfield playing bongos",
                "Prism",
                "Retro car",
                "Triumph motorcycle"
            };
            int productId = 0;
            int descriptionId = 0;
            foreach (var c in Category)
            {
                for (var i = 0; i < 25; i++)
                {
                    if (descriptionId == description.Length) descriptionId = 0;
                    var desc = description[descriptionId++];

                    Products.Add(new Product
                    {
                        CategoryId = c.CategoryId,
                        Category = c,
                        IsVisible = true,
                        ProductId = productId++,
                        Price = 12.99M,
                        Title = $"{c.Name} ({desc})",
                        Options = new Dictionary<string,string[]>()  
                        {
                            { "Size", new[]{"XS","S","M","L","XL" } },
                            { "Colour", new[]{"Red","Green","Blue"} }
                        },
                        SubTitle = $"A nice T-shirt with a print of {desc}"
                    });
                }
            }
        }

        public List<Category> Category { get; set; } = new List<Category>();

        public List<Product> Products { get; set; } = new List<Product>();

        public void Dispose()
        {
        }
    }
}