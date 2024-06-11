using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Windows;
using System.Data;
using System.Net.Mail;
namespace DataAccessLayer
{
    public static class CustomerDAO
    {
         static SqlConnection connection;
         static SqlCommand command;
         static string connectionString = "Data Source=LAPTOP-RK5LE9QJ\\SQLEXPRESS01;Initial Catalog=HoaLacLapTopShop;Persist Security Info=True;User ID=sa;Password=sa;Trust Server Certificate=True";

        public static List<Customer> GetCustomer()
        {
            List<Customer> customer = new List<Customer>();
            connection = new SqlConnection(connectionString);
            string SQL = "SELECT CustomerID, CustomerFullName, Telephone, EmailAddress, CustomerBirthday, CustomerStatus, Password from [FUMiniHotelManagement].[dbo].[Customer]";
            command = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        customer.Add(new Customer
                        {
                            CustomerID = reader.GetInt32("CustomerID"),
                            CustomerFullName = reader.GetString("ProductName"),
                            Telephone = reader.GetString("Telephone"),
                            EmailAddress = reader.GetString("EmailAddress"),
                            CustomerBirthday = reader.GetDateTime("CustomerBirthday"),
                            CustomerStatus = reader.GetInt16("CustomerStatus"),
                            Password = reader.GetString("Password"),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return customer;
        }
        public static void CreateCustomer(Customer customer)
        {
            connection = new SqlConnection(connectionString);
            string SQL = "INSERT INTO [FUMiniHotelManagement].[dbo].[Customer] (CustomerFullName, EmailAddress, CustomerBirthday, CustomerStatus, CustomerPassword) VALUES (@CustomerFullName, @EmailAddress, @CustomerBirthday, @CustomerStatus, @CustomerPassword)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@MemberPassword", customer.Password);
                command.Parameters.AddWithValue("@Telephone", customer.CustomerFullName);
                command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
                command.Parameters.AddWithValue("@CustomerBirthday", customer.CustomerBirthday);
                command.Parameters.AddWithValue("@CustomerStatus", 1);
                command.Parameters.AddWithValue("@Password", customer.Password);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static Customer UpdateCustomer(Customer customer)
        {
            

            connection = new SqlConnection(connectionString);
           
                
                connection = new SqlConnection(connectionString);
                string SQL = "UPDATE [FUMiniHotelManagement].[dbo].[Customer] WHERE CustomerID = @CustomerID";
            try    
            {
                    command.Parameters.AddWithValue("@CustomerID", customer);

                    SqlDataReader reader = command.ExecuteReader();

                connection.Open();
                command.Parameters.AddWithValue("@MemberPassword", customer.Password);
                command.Parameters.AddWithValue("@Telephone", customer.CustomerFullName);
                command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
                command.Parameters.AddWithValue("@CustomerBirthday", customer.CustomerBirthday);
                command.Parameters.AddWithValue("@CustomerStatus", customer.CustomerStatus);
                command.Parameters.AddWithValue("@Password", customer.Password);
                command.ExecuteNonQuery();
                   
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return customer;
        }
        public static void DeleteCustomer(Customer customer)
        {
            /*string confirmDelete = MessageBox.Show("Are you sure you want to delete customer " + customer.CustomerName + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(confirmDelete==DialogResult.Yes)*/
            connection = new SqlConnection(connectionString);
            string SQL = "Delete [FUMiniHotelManagement].[dbo].[Customer] where CustomerID=@CustomerID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static Customer GetCustomerById(int id)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string SQL = "SELECT * FROM [FUMiniHotelManagement].[dbo].[Customer] WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@CustomerID", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = reader.GetInt32("CustomerID");
                    customer.CustomerFullName = reader.GetString("ProductName");
                    customer.Telephone = reader.GetString("Telephone");
                    customer.EmailAddress = reader.GetString("EmailAddress");
                    customer.CustomerBirthday = reader.GetDateTime("CustomerBirthday");
                    customer.CustomerStatus = reader.GetInt16("CustomerStatus");
                    customer.Password = reader.GetString("Password");
                    return customer;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
