namespace SupermarketApp.Models
{
    public class Product
    {
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int BrandID { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public decimal CostPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockLevel { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}