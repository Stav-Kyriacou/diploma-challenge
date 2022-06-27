using System;
using Xunit;

namespace tests
{
    public class OrderTests
    {
        [Theory]
        [InlineData(1, 1f)]
        [InlineData(0, 0f)]
        [InlineData(-1, -10f)]
        [InlineData(0, -10f)]
        [InlineData(-10, 0f)]
        public void OrderValueTest(int quantity, float unitPrice)
        {
            if (quantity <= 0)
            {
                quantity = 1;
            }
            if (unitPrice <= 0)
            {
                unitPrice = 0;
            }
            Product prod = new Product() { UnitPrice = unitPrice };
            Order order = new Order() { Quantity = quantity, Product = prod };
            Assert.True(order.CalculateOrderValue() >= 0f);
        }
        [Theory]
        [InlineData(1, 1f)]
        [InlineData(0, 0f)]
        [InlineData(-1, -10f)]
        [InlineData(0, -10f)]
        [InlineData(-10, 0f)]
        public void GSTTest(int quantity, float unitPrice)
        {
            Product prod = new Product() { UnitPrice = unitPrice };
            Order order = new Order() { Quantity = quantity, Product = prod };
            Assert.True(order.CalculateGST() >= 0f);
        }
    }
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public int Quantity { get; set; }
        public string ShipDate { get; set; }
        public string CustID { get; set; }
        public string ProdID { get; set; }
        public string ShipMode { get; set; }
        public Product Product { get; set; }
        public float CalculateOrderValue()
        {
            return this.Quantity * this.Product.UnitPrice;
        }
        public float CalculateGST()
        {
            return this.CalculateOrderValue() * 0.1f;
        }
    }
    public class Product
    {
        public string ProdID { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int CatID { get; set; }
    }
}
