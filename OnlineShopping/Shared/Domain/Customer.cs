using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Shared.Domain
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Full_name { get; set; }
        public string Billing_address { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Default_shipping_address { get; set; }
    }
}
