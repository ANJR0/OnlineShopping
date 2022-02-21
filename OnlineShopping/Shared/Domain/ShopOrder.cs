using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Shared.Domain
{
    public class ShopOrder
    {
        public int ShopOrderID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ShopOrderDATE { get; set; }
        [Required]
        public string ShopOrderSTATUS { get; set; }
        [Required]
        public int? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public int? StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        [Required]
        public int? DeliveryID { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
