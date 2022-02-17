using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Shared.Domain
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int ShopOrderID { get; set; }
        public virtual ShopOrder ShopOrder { get; set; }
    }
}
