using BusinessObject;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public static class BookingDetailDAO
    {
        static SqlConnection connection;
        static SqlCommand command;
        static string connectionString = "Data Source=LAPTOP-RK5LE9QJ\\SQLEXPRESS01;Initial Catalog=HoaLacLapTopShop;Persist Security Info=True;User ID=sa;Password=sa;Trust Server Certificate=True";
        public static List<BookingDetail> GetBookingDetail()
        {
            List<BookingDetail> booking = new List<BookingDetail>();
            connection = new SqlConnection(connectionString);
            string SQL = "SELECT BookingReservationID, RoomID, StartDate, EndDate, ActualPrice from [FUMiniHotelManagement].[dbo].[BookingDetail]";
            command = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        booking.Add(new BookingDetail
                        {
                            BookingReservationID = reader.GetInt32("BookingReservationID"),
                            RoomID = reader.GetInt32("RoomID"),
                            StartDate = reader.GetDateTime("StartDate"),
                            EndDate = reader.GetDateTime("EndDate"),
                            ActualPrice = reader.GetDecimal("ActualPrice")
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
            return booking;
        }
        public static void AddBookingDetail(BookingDetail booking)
        {
            connection = new SqlConnection(connectionString);
            string SQL = "INSERT INTO [FUMiniHotelManagement].[dbo].[BookingDetail] (BookingReservationID, RoomID, StartDate, EndDate, ActualPrice) VALUES (@ProductName, @CategoryID, @UnitsInStock, @UnitPrice)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@BookingReservationID", booking.BookingReservationID);
                command.Parameters.AddWithValue("@RoomID", booking.RoomID);
                command.Parameters.AddWithValue("@StartDate", booking.StartDate);
                command.Parameters.AddWithValue("@EndDate", booking.EndDate);
                command.Parameters.AddWithValue("@ActualPrice", booking.ActualPrice);
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
        
    }
}
