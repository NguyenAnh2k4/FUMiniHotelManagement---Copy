using System;
using Microsoft.Data.SqlClient;
using System.Data;
using BusinessObjects;
using System.Linq;
using System.Windows.Input;
namespace DataAccessLayer
{

    public static class ProductDAO
    {
        static SqlConnection connection;
        static SqlCommand command;
        static string ConnectionString = "Data Source=LAPTOP-RK5LE9QJ\\SQLEXPRESS01;Initial Catalog=HoaLacLapTopShop;Persist Security Info=True;User ID=sa;Password=sa;Trust Server Certificate=True";
        public static Product GetProductById(int id)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string SQL = "SELECT * FROM [MyStore].[dbo].[Products] WHERE ProductID = @id";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)reader["ProductID"];
                    product.ProductName = (string)reader["ProductName"];
                    product.CategoryId = (int)reader["CategoryId"];
                    product.UnitsInStock = (short)reader["UnitsInStock"];
                    product.UnitPrice = (decimal)reader["UnitPrice"];
                    return product;
                }
                else
                {
                    return null;
                }
            }
        }
    }
