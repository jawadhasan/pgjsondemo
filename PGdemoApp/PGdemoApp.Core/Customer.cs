using System;
using System.Collections.Generic;
using System.Text;

namespace PGdemoApp.Core
{

    public class CustomerDoc 
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
    }
    public class Customer // Mapped to a JSON column in the table
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }

    public class Order       // Part of the JSON column
    {
        public decimal Price { get; set; }
        public string ShippingAddress { get; set; }
    }
}
