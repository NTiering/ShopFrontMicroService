namespace ShopFront.Inventory.DataModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public decimal Price { get; set; }
        public bool IsVisible { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}