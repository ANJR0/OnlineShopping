using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Shared.Domain
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Datetime { get; set; }
        public int ShopOrderID { get; set; }
        public virtual ShopOrder ShopOrder { get; set; }
    }
}
