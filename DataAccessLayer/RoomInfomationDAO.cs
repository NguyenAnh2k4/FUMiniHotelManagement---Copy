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
    public static class RoomInformationDAO
    {
        static SqlConnection connection;
        static SqlCommand command;
        static string connectionString = "Data Source=LAPTOP-RK5LE9QJ\\SQLEXPRESS01;Initial Catalog=HoaLacLapTopShop;Persist Security Info=True;User ID=sa;Password=sa;Trust Server Certificate=True";
        public static void CreateRoom(RoomInfomation room)
        {
            connection = new SqlConnection(connectionString);
            string SQL = "INSERT INTO [FUMiniHotelManagement].[dbo].[RoomInformation](RoomNumber,RoomDetailDescription,RoomMaxCapacity,RoomTypeID,RoomStatus, RoomPricePerDay) VALUES (@RoomNumber,@RoomDetailDescription,@RoomMaxCapacity,@RoomTypeID,@RoomPricePerDay)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                command.Parameters.AddWithValue("@RoomDetailDescription", room.RoomDetailDescription);
                command.Parameters.AddWithValue("@RoomMaxCapacity", room.RoomMaxCapacity);
                command.Parameters.AddWithValue("@RoomTypeID", room.RoomTypeID);
                command.Parameters.AddWithValue("@RoomStatus", 1);
                command.Parameters.AddWithValue("@RoomPricePerDay", room.RoomPricePerDay);
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
        public static void DeleteRoom(RoomInfomation room)
        {
            /*string confirmDelete = MessageBox.Show("Are you sure you want to delete customer " + customer.CustomerName + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(confirmDelete==DialogResult.Yes)*/
            connection = new SqlConnection(connectionString);
            string SQL = "Delete [FUMiniHotelManagement].[dbo].[RoomTypeInformation] where RoomID=@RoomID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@RoomID", room.RoomID);
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
        public static List<RoomInfomation> GetRoomInformation()
        {
            List<RoomInfomation> room = new List<RoomInfomation>();
            connection = new SqlConnection(connectionString);
            string SQL = "SELECT RoomID, RoomNumber, RoomDetailDescription, RoomMaxCapacity, RoomTypeID, RoomStatus RoomPricePerDay from [MyStore].[dbo].[Products]";
            command = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        room.Add(new RoomInfomation
                        {
                            RoomID = reader.GetInt32("RoomID"),
                            RoomNumber = reader.GetString("RoomNumber"),
                            RoomDetailDescription = reader.GetString("RoomDetailDescription"),
                            RoomMaxCapacity = reader.GetInt32("RoomMaxCapacity"),
                            RoomTypeID = reader.GetInt32("RoomTypeID"),
                            RoomStatus = reader.GetInt16("RoomStatus"),
                            RoomPricePerDay=reader.GetDecimal("RoomPricePerDay")
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
            return room;
        }
        public static void UpdateRoomInfo(RoomInfomation room)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string SQL = "UPDATE [FUMiniHotelManagement].[dbo].[RoomInformation] SET RoomNumber = @RoomNumber, RoomDetailDescription = @RoomDetailDescription, RoomMaxCapacity = @RoomMaxCapacity, RoomTypeID = @RoomTypeID, RoomStatus = @RoomStatus, RoomPricePerDay = @RoomPricePerDay WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@RoomID", room.RoomID);
                command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                command.Parameters.AddWithValue("@RoomDetailDescription", room.RoomDetailDescription);
                command.Parameters.AddWithValue("@RoomTypeID", room.RoomTypeID);                
                command.Parameters.AddWithValue("@RoomMaxCapacity", room.RoomMaxCapacity);
                command.Parameters.AddWithValue("@RoomPricePerDay", room.RoomPricePerDay);
                try
                {
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
}