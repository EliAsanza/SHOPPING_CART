namespace SHOPPINGCART.Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingcartId { get; set; }
        public Customer CustomerId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
