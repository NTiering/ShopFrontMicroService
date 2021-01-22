using System.Collections.Generic;

namespace ShopFront.Inventory.DataModels
{
    public class Product
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsVisible { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public Dictionary<string, string[]> Options { get; set; }
    }
}