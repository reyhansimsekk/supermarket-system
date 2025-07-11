using SupermarketApp.Data;
using SupermarketApp.Models;
using MySql.Data.MySqlClient;

namespace SupermarketApp.BusinessLogic
{
    public static class SalesManager
    {
        public static bool SaveSale(Sale sale)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Ana satış kaydını ekle
                            string insertSaleQuery = @"
                                INSERT INTO Sales (SaleDate, UserID, TotalAmount, PaymentType, DiscountAmount, NetAmount) 
                                VALUES (@SaleDate, @UserID, @TotalAmount, @PaymentType, @DiscountAmount, @NetAmount);
                                SELECT LAST_INSERT_ID();";

                            var saleCommand = new MySqlCommand(insertSaleQuery, connection, transaction);
                            saleCommand.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                            saleCommand.Parameters.AddWithValue("@UserID", sale.UserID);
                            saleCommand.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);
                            saleCommand.Parameters.AddWithValue("@PaymentType", sale.PaymentType);
                            saleCommand.Parameters.AddWithValue("@DiscountAmount", sale.DiscountAmount);
                            saleCommand.Parameters.AddWithValue("@NetAmount", sale.NetAmount);

                            int saleId = Convert.ToInt32(saleCommand.ExecuteScalar());

                            // 2. Satış detaylarını ekle ve stokları güncelle
                            foreach (var detail in sale.SaleDetails)
                            {
                                // Satış detayını ekle
                                string insertDetailQuery = @"
                                    INSERT INTO SalesDetails (SaleID, ProductCode, Quantity, UnitPrice, TotalPrice, DiscountAmount) 
                                    VALUES (@SaleID, @ProductCode, @Quantity, @UnitPrice, @TotalPrice, @DiscountAmount)";

                                var detailCommand = new MySqlCommand(insertDetailQuery, connection, transaction);
                                detailCommand.Parameters.AddWithValue("@SaleID", saleId);
                                detailCommand.Parameters.AddWithValue("@ProductCode", detail.ProductCode);
                                detailCommand.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                detailCommand.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);
                                detailCommand.Parameters.AddWithValue("@TotalPrice", detail.TotalPrice);
                                detailCommand.Parameters.AddWithValue("@DiscountAmount", detail.DiscountAmount);

                                detailCommand.ExecuteNonQuery();

                                // Stoku güncelle (sadece bir kez)
                                string updateStockQuery = @"
                                    UPDATE Products 
                                    SET StockQuantity = StockQuantity - @Quantity,
                                        ModifiedDate = NOW()
                                    WHERE ProductCode = @ProductCode";

                                var stockCommand = new MySqlCommand(updateStockQuery, connection, transaction);
                                stockCommand.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                stockCommand.Parameters.AddWithValue("@ProductCode", detail.ProductCode);

                                stockCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Satış kaydedilirken hata: {ex.Message}");
            }
        }

        public static List<Sale> GetSalesByDate(DateTime date)
        {
            var sales = new List<Sale>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    
                    string query = @"
                        SELECT s.*, u.FullName as CashierName
                        FROM Sales s
                        INNER JOIN Users u ON s.UserID = u.UserID
                        WHERE DATE(s.SaleDate) = @Date
                        ORDER BY s.SaleDate DESC";

                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Date", date.Date);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sale = new Sale
                            {
                                SaleID = reader.GetInt32("SaleID"),
                                SaleDate = reader.GetDateTime("SaleDate"),
                                UserID = reader.GetInt32("UserID"),
                                TotalAmount = reader.GetDecimal("TotalAmount"),
                                PaymentType = reader.GetString("PaymentType"),
                                DiscountAmount = reader.GetDecimal("DiscountAmount"),
                                NetAmount = reader.GetDecimal("NetAmount"),
                                IsReturned = reader.GetBoolean("IsReturned")
                            };
                            
                            sales.Add(sale);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Satış listesi alınırken hata: {ex.Message}");
            }
            
            return sales;
        }

        public static List<SaleDetail> GetSaleDetails(int saleId)
        {
            var details = new List<SaleDetail>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    
                    string query = @"
                        SELECT sd.*, p.ProductName
                        FROM SalesDetails sd
                        INNER JOIN Products p ON sd.ProductCode = p.ProductCode
                        WHERE sd.SaleID = @SaleID";

                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SaleID", saleId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var detail = new SaleDetail
                            {
                                SalesDetailID = reader.GetInt32("SalesDetailID"),
                                SaleID = reader.GetInt32("SaleID"),
                                ProductCode = reader.GetString("ProductCode"),
                                ProductName = reader.GetString("ProductName"),
                                Quantity = reader.GetInt32("Quantity"),
                                UnitPrice = reader.GetDecimal("UnitPrice"),
                                TotalPrice = reader.GetDecimal("TotalPrice"),
                                DiscountAmount = reader.GetDecimal("DiscountAmount")
                            };
                            
                            details.Add(detail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Satış detayları alınırken hata: {ex.Message}");
            }
            
            return details;
        }

        public static (decimal revenue, decimal cost, decimal profit) GetDailySummary(DateTime date)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    
                    string query = @"
                        SELECT 
                            COALESCE(SUM(s.NetAmount), 0) as Revenue,
                            COALESCE(SUM(sd.Quantity * p.CostPrice), 0) as Cost
                        FROM Sales s
                        INNER JOIN SalesDetails sd ON s.SaleID = sd.SaleID
                        INNER JOIN Products p ON sd.ProductCode = p.ProductCode
                        WHERE DATE(s.SaleDate) = @Date AND s.IsReturned = 0";

                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Date", date.Date);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal revenue = reader.GetDecimal("Revenue");
                            decimal cost = reader.GetDecimal("Cost");
                            decimal profit = revenue - cost;
                            
                            return (revenue, cost, profit);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Günlük özet alınırken hata: {ex.Message}");
            }
            
            return (0, 0, 0);
        }
    }
}