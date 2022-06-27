using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using api.Models;

namespace api.Handlers
{
    public class OrderHandler : DatabaseHandler
    {
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [Order]", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order()
                            {
                                OrderID = reader.GetInt32(0),
                                OrderDate = reader.GetDateTime(1),
                                Quantity = reader.GetInt32(2),
                                ShipDate = reader.GetDateTime(3),
                                CustID = reader.GetString(4),
                                ProdID = reader.GetString(5),
                                ShipMode = reader.GetString(6)
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (orders.Count == 0) return null;

            return orders;
        }

        public int CreateNewOrder(string custID, string prodID, int quantity, DateTime orderDate, DateTime shipDate, string shipMode)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ADD_ORDER", conn))
                {
                    // @pOrderID INT OUTPUT,
                    // @pCustID NVARCHAR(20),
                    // @pProdID NVARCHAR(30),
                    // @pOrderDate DATE,
                    // @pQuantity INT,
                    // @pShipDate DATE,
                    // @pShipMode NVARCHAR(50)
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pOrderID", 0);
                    command.Parameters.AddWithValue("@pCustID", custID);
                    command.Parameters.AddWithValue("@pProdID", prodID);
                    command.Parameters.AddWithValue("@pOrderDate", orderDate);
                    command.Parameters.AddWithValue("@pQuantity", quantity);
                    command.Parameters.AddWithValue("@pShipDate", shipDate);
                    command.Parameters.AddWithValue("@pShipMode", shipMode);

                    var returnParameter = command.Parameters.Add("@pOwnerID", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    conn.Close();
                    return (int)result;
                }
            }
        }
        public int DeleteOrder(int orderID)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("DELETE_ORDER", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pOrderID", orderID);

                    rowsAffected = command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return rowsAffected;
        }
    }
}