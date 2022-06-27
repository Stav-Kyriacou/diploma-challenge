using System;

namespace api.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public DateTime ShipDate { get; set; }
        public string CustID { get; set; }
        public string ProdID { get; set; }
        public string ShipMode { get; set; }
    }
}