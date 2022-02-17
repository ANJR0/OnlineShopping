using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Shared.Domain
{
    public class ShopOrder
    {
        public int ShopOrderID { get; set; }
        public DateTime ShopOrderDATE { get; set; }
        public string ShopOrderSTATUS { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int? StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        public int? DeliveryID { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
