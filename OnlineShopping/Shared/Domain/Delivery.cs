using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Shared.Domain
{
    public class Delivery
    {
        public int DeliveryID { get; set; }
        public DateTime DeliveryDATE { get; set; }
        public int StaffID { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
