﻿using System.Collections.Generic;

namespace ShopFront.Inventory.DataModels
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}