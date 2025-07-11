using MySql.Data.MySqlClient;
using SupermarketApp.Data;
using SupermarketApp.Models;
using System.Data;

namespace SupermarketApp.BusinessLogic
{
    public class ProductManager
    {
        public static List<Product> GetAllProducts()
        {
            try
            {
                string query = @"
                    SELECT p.ProductCode, p.ProductName, p.CategoryID, c.CategoryName,
                           p.BrandID, b.BrandName, p.CostPrice, p.UnitPrice, p.StockQuantity, 
                           p.MinStockLevel, p.IsActive, p.CreatedDate, p.ModifiedDate
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                    LEFT JOIN Brands b ON p.BrandID = b.BrandID
                    WHERE p.IsActive = 1
                    ORDER BY p.ProductName";

                var dataTable = DatabaseConnection.ExecuteQuery(query);
                var products = new List<Product>();

                foreach (DataRow row in dataTable.Rows)
                {
                    products.Add(new Product
                    {
                        ProductCode = row["ProductCode"].ToString() ?? string.Empty,
                        ProductName = row["ProductName"].ToString() ?? string.Empty,
                        CategoryID = Convert.ToInt32(row["CategoryID"]),
                        CategoryName = row["CategoryName"].ToString() ?? string.Empty,
                        BrandID = Convert.ToInt32(row["BrandID"]),
                        BrandName = row["BrandName"].ToString() ?? string.Empty,
                        CostPrice = Convert.ToDecimal(row["CostPrice"]),
                        UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                        StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                        MinStockLevel = Convert.ToInt32(row["MinStockLevel"]),
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"])
                    });
                }

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ürünler alınırken hata: {ex.Message}");
            }
        }

        public static Product? GetProductByCode(string productCode)
        {
            try
            {
                string query = @"
                    SELECT p.ProductCode, p.ProductName, p.CategoryID, c.CategoryName,
                           p.BrandID, b.BrandName, p.CostPrice, p.UnitPrice, p.StockQuantity, 
                           p.MinStockLevel, p.IsActive, p.CreatedDate, p.ModifiedDate
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                    LEFT JOIN Brands b ON p.BrandID = b.BrandID
                    WHERE p.ProductCode = @ProductCode AND p.IsActive = 1";

                var parameter = new MySqlParameter("@ProductCode", productCode);
                var dataTable = DatabaseConnection.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];
                    return new Product
                    {
                        ProductCode = row["ProductCode"].ToString() ?? string.Empty,
                        ProductName = row["ProductName"].ToString() ?? string.Empty,
                        CategoryID = Convert.ToInt32(row["CategoryID"]),
                        CategoryName = row["CategoryName"].ToString() ?? string.Empty,
                        BrandID = Convert.ToInt32(row["BrandID"]),
                        BrandName = row["BrandName"].ToString() ?? string.Empty,
                        CostPrice = Convert.ToDecimal(row["CostPrice"]),
                        UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                        StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                        MinStockLevel = Convert.ToInt32(row["MinStockLevel"]),
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"])
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ürün bilgisi alınırken hata: {ex.Message}");
            }
        }

        public static bool AddProduct(Product product)
        {
            try
            {
                string query = @"
                    INSERT INTO Products (ProductCode, ProductName, CategoryID, BrandID, CostPrice, UnitPrice, 
                                        StockQuantity, MinStockLevel, IsActive) 
                    VALUES (@ProductCode, @ProductName, @CategoryID, @BrandID, @CostPrice, @UnitPrice, 
                            @StockQuantity, @MinStockLevel, @IsActive)";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@ProductCode", product.ProductCode),
                    new MySqlParameter("@ProductName", product.ProductName),
                    new MySqlParameter("@CategoryID", product.CategoryID),
                    new MySqlParameter("@BrandID", product.BrandID),
                    new MySqlParameter("@CostPrice", product.CostPrice),
                    new MySqlParameter("@UnitPrice", product.UnitPrice),
                    new MySqlParameter("@StockQuantity", product.StockQuantity),
                    new MySqlParameter("@MinStockLevel", product.MinStockLevel),
                    new MySqlParameter("@IsActive", product.IsActive)
                };

                return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ürün eklenirken hata: {ex.Message}");
            }
        }

        public static bool UpdateProduct(Product product)
        {
            try
            {
                string query = @"
                    UPDATE Products 
                    SET ProductName = @ProductName, CategoryID = @CategoryID, BrandID = @BrandID,
                        CostPrice = @CostPrice, UnitPrice = @UnitPrice, StockQuantity = @StockQuantity, 
                        MinStockLevel = @MinStockLevel, IsActive = @IsActive,
                        ModifiedDate = NOW()
                    WHERE ProductCode = @ProductCode";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@ProductCode", product.ProductCode),
                    new MySqlParameter("@ProductName", product.ProductName),
                    new MySqlParameter("@CategoryID", product.CategoryID),
                    new MySqlParameter("@BrandID", product.BrandID),
                    new MySqlParameter("@CostPrice", product.CostPrice),
                    new MySqlParameter("@UnitPrice", product.UnitPrice),
                    new MySqlParameter("@StockQuantity", product.StockQuantity),
                    new MySqlParameter("@MinStockLevel", product.MinStockLevel),
                    new MySqlParameter("@IsActive", product.IsActive)
                };

                return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ürün güncellenirken hata: {ex.Message}");
            }
        }

        public static bool DeleteProduct(string productCode)
        {
            try
            {
                string query = "UPDATE Products SET IsActive = 0 WHERE ProductCode = @ProductCode";
                var parameter = new MySqlParameter("@ProductCode", productCode);

                return DatabaseConnection.ExecuteNonQuery(query, parameter) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ürün silinirken hata: {ex.Message}");
            }
        }

        public static List<Category> GetAllCategories()
        {
            try
            {
                string query = "SELECT CategoryID, CategoryName, IsActive FROM Categories WHERE IsActive = 1 ORDER BY CategoryName";
                var dataTable = DatabaseConnection.ExecuteQuery(query);
                var categories = new List<Category>();

                foreach (DataRow row in dataTable.Rows)
                {
                    categories.Add(new Category
                    {
                        CategoryID = Convert.ToInt32(row["CategoryID"]),
                        CategoryName = row["CategoryName"].ToString() ?? string.Empty,
                        IsActive = Convert.ToBoolean(row["IsActive"])
                    });
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception($"Kategoriler alınırken hata: {ex.Message}");
            }
        }

        public static List<Brand> GetAllBrands()
        {
            try
            {
                string query = "SELECT BrandID, BrandName, IsActive FROM Brands WHERE IsActive = 1 ORDER BY BrandName";
                var dataTable = DatabaseConnection.ExecuteQuery(query);
                var brands = new List<Brand>();

                foreach (DataRow row in dataTable.Rows)
                {
                    brands.Add(new Brand
                    {
                        BrandID = Convert.ToInt32(row["BrandID"]),
                        BrandName = row["BrandName"].ToString() ?? string.Empty,
                        IsActive = Convert.ToBoolean(row["IsActive"])
                    });
                }

                return brands;
            }
            catch (Exception ex)
            {
                throw new Exception($"Markalar alınırken hata: {ex.Message}");
            }
        }

        public static List<Product> GetLowStockProducts()
        {
            try
            {
                var dataTable = DatabaseConnection.ExecuteQuery("CALL sp_CheckLowStock()");
                var products = new List<Product>();

                foreach (DataRow row in dataTable.Rows)
                {
                    products.Add(new Product
                    {
                        ProductCode = row["ProductCode"].ToString() ?? string.Empty,
                        ProductName = row["ProductName"].ToString() ?? string.Empty,
                        StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                        MinStockLevel = Convert.ToInt32(row["MinStockLevel"]),
                        CategoryName = row["CategoryName"].ToString() ?? string.Empty,
                        BrandName = row["BrandName"].ToString() ?? string.Empty
                    });
                }

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception($"Düşük stok listesi alınırken hata: {ex.Message}");
            }
        }
    }
}