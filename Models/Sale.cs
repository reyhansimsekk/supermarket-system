namespace SupermarketApp.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public DateTime SaleDate { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public bool IsReturned { get; set; }
        public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }

    public class SaleDetail
    {
        public int SalesDetailID { get; set; }
        public int SaleID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
    }

    public enum PaymentTypeEnum
    {
        Nakit,
        Kart
    }
}