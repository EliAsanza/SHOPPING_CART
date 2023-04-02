namespace SHOPPINGCART.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brand oBrandId { get; set; }
        public Category oCategoryId { get; set; }
        public decimal Price { get; set; }
        public string PriceText { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public bool Active { get; set; }
        public string Base64 { get; set; }
        public string Extension { get; set; }
    }
}
