namespace SHOPPINGCART.Domain.Entities
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal {get; set; }
        public string TransactionId { get; set; }
    }
}
