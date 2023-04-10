namespace SHOPPINGCART.Domain.Entities
{
    public class Reports
    {
        public string Saledate { get; set; }
        public string Customer { get; set;}
        public string Product { get; set;}
        public decimal Price { get; set;}
        public int Quantity { get; set;}
        public decimal Subtotal { get; set;}
        public decimal TotalAmount { get; set;}
        public string TransactionId { get; set;}   
    }
}
