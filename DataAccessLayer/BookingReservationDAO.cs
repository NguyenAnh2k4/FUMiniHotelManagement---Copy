using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Windows;
using System.Data;
namespace DataAccessLayer
{
    public static class AccountDAO
    {
        static SqlConnection connection;
        static SqlCommand command;
        static string connectionString = "Data Source=LAPTOP-RK5LE9QJ\\SQLEXPRESS01;Initial Catalog=HoaLacLapTopShop;Persist Security Info=True;User ID=sa;Password=sa;Trust Server Certificate=True";
        public static List<BookingReservation> GetBookingReservation()
        {
            List<BookingReservation> reservation = new List<BookingReservation>();
            connection = new SqlConnection(connectionString);
            string SQL = "SELECT BookingReservationID, BookingDate, TotalPrice, CustomerID, BookingStatus FROM [FUMiniHotelManagement].[dbo].[BookingReservation]";
            command = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        reservation.Add(new BookingReservation
                        {
                            BookingReservationID = reader.GetInt32("BookingReservation"),
                            BookingDate = reader.GetDateTime("BookingDate"),
                            TotalPrice = reader.GetDecimal("TotalPrice"),
                            CustomerID = reader.GetInt32("CustomerID"),
                            BookingStatus= reader.GetInt16("BookingStatus")                          
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
            return reservation;
        }
    }
}
