using MySql.Data.MySqlClient;
using SupermarketApp.Data;
using SupermarketApp.Models;
using System.Data;

namespace SupermarketApp.BusinessLogic
{
    public class UserManager
    {
        public static User? AuthenticateUser(string username, string password)
        {
            try
            {
                string query = @"
                    SELECT UserID, Username, Password, FullName, UserType, IsActive, CreatedDate 
                    FROM Users 
                    WHERE Username = @Username AND Password = @Password AND IsActive = 1";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Username", username),
                    new MySqlParameter("@Password", password)
                };

                var dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];
                    return new User
                    {
                        UserID = Convert.ToInt32(row["UserID"]),
                        Username = row["Username"].ToString() ?? string.Empty,
                        Password = row["Password"].ToString() ?? string.Empty,
                        FullName = row["FullName"].ToString() ?? string.Empty,
                        UserType = row["UserType"].ToString() ?? string.Empty,
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı doğrulama hatası: {ex.Message}");
            }
        }

        public static List<User> GetAllUsers()
        {
            try
            {
                string query = @"
                    SELECT UserID, Username, FullName, UserType, IsActive, CreatedDate 
                    FROM Users 
                    ORDER BY FullName";

                var dataTable = DatabaseConnection.ExecuteQuery(query);
                var users = new List<User>();

                foreach (DataRow row in dataTable.Rows)
                {
                    users.Add(new User
                    {
                        UserID = Convert.ToInt32(row["UserID"]),
                        Username = row["Username"].ToString() ?? string.Empty,
                        FullName = row["FullName"].ToString() ?? string.Empty,
                        UserType = row["UserType"].ToString() ?? string.Empty,
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                    });
                }

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı listesi alınırken hata: {ex.Message}");
            }
        }

        public static bool AddUser(User user)
        {
            try
            {
                string query = @"
                    INSERT INTO Users (Username, Password, FullName, UserType, IsActive) 
                    VALUES (@Username, @Password, @FullName, @UserType, @IsActive)";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Username", user.Username),
                    new MySqlParameter("@Password", user.Password),
                    new MySqlParameter("@FullName", user.FullName),
                    new MySqlParameter("@UserType", user.UserType),
                    new MySqlParameter("@IsActive", user.IsActive)
                };

                return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı eklenirken hata: {ex.Message}");
            }
        }

        public static bool UpdateUser(User user)
        {
            try
            {
                string query = @"
                    UPDATE Users 
                    SET Username = @Username, Password = @Password, FullName = @FullName, 
                        UserType = @UserType, IsActive = @IsActive 
                    WHERE UserID = @UserID";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@UserID", user.UserID),
                    new MySqlParameter("@Username", user.Username),
                    new MySqlParameter("@Password", user.Password),
                    new MySqlParameter("@FullName", user.FullName),
                    new MySqlParameter("@UserType", user.UserType),
                    new MySqlParameter("@IsActive", user.IsActive)
                };

                return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı güncellenirken hata: {ex.Message}");
            }
        }

        public static bool DeleteUser(int userID)
        {
            try
            {
                string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID";
                var parameter = new MySqlParameter("@UserID", userID);

                return DatabaseConnection.ExecuteNonQuery(query, parameter) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı silinirken hata: {ex.Message}");
            }
        }
    }
}