using System;

namespace api.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public int Quantity { get; set; }
        public string ShipDate { get; set; }
        public string CustID { get; set; }
        public string ProdID { get; set; }
        public string ShipMode { get; set; }
    }
}