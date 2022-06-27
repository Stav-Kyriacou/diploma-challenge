using System;

namespace api.Models
{
    public class Product
    {
        public string ProdID { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int CatID { get; set; }
    }
}