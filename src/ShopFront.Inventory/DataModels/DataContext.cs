using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ShopFront.Inventory.DataModels
{
    public class TempDataContext : IDisposable
    {
        public List<Category> Category { get; set; } = new List<Category>();

        public List<Product> Products { get; set; } = new List<Product>();

        public TempDataContext()
        {
            Category.AddRange(new[]
            {

                        new Category { CategoryId = 1, Name = "Mens", Description = "Mens T-Shirts" },
                        new Category { CategoryId = 2, Name = "Womens", Description = "Womens T-Shirts" },
                        new Category { CategoryId = 3, Name = "Kids", Description = "Kids T-Shirts" },
                        new Category { CategoryId = 4, Name = "Sale", Description = "Upto 30% off" },
                        new Category { CategoryId = 5, Name = "10% off", Description = "Up to 10% off", ParentCategoryId = 4 },
                        new Category { CategoryId = 6, Name = "20% off", Description = "Up to 20% off", ParentCategoryId = 4 },
                        new Category { CategoryId = 7, Name = "30% off", Description = "Up to 30% off", ParentCategoryId = 4 },

                        new Category { CategoryId = 5, Name = "Small", Description = "Tiny tees", ParentCategoryId = 1 },
                        new Category { CategoryId = 6, Name = "Med", Description = "Regular Tees", ParentCategoryId = 1 },
                        new Category { CategoryId = 7, Name = "Large", Description = "Bigger Tees", ParentCategoryId = 1 },

                        new Category { CategoryId = 8, Name = "Small", Description = "Tiny tees", ParentCategoryId = 2 },
                        new Category { CategoryId = 9, Name = "Med", Description = "Regular Tees", ParentCategoryId = 2 },
                        new Category { CategoryId = 10, Name = "Large", Description = "Bigger Tees", ParentCategoryId = 2 },

                        new Category { CategoryId = 11, Name = "Small", Description = "0-1 years", ParentCategoryId = 3 },
                        new Category { CategoryId = 12, Name = "Med", Description = "1-3 years", ParentCategoryId = 3 },
                        new Category { CategoryId = 13, Name = "Large", Description = "5-10 years", ParentCategoryId = 3 }

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
                        SubTitle = $"A nice T-shirt with a print of {desc}"
                    });
                }
            }
        }

        public void Dispose()
        {
        }
    }

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
}