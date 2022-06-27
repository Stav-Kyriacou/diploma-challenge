using System.Collections.Generic;
using System.Data.SqlClient;
using api.Models;

namespace api.Handlers
{
    public class ProductHandler : DatabaseHandler
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Product", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product()
                            {
                                ProdID = reader.GetString(0),
                                Description = reader.GetString(1),
                                UnitPrice = (float)reader.GetDouble(2),
                                CatID = reader.GetInt32(3)
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (products.Count == 0) return null;

            return products;
        }
    }
}