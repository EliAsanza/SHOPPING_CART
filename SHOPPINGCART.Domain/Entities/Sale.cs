using System.Collections.Generic;

namespace SHOPPINGCART.Domain.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int TotalProduct { get; set; }
        public decimal TotalAmount { get; set; }
        public string Contact { get; set; }
        public string TownId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string SaleDate { get; set; }
        public string TransactionId { get; set; }
        public List<SaleDetail> SaleDetailId { get; set;}
    }
}
