using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Shared.Domain
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int? ProductID { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int? ShopOrderID { get; set; }
        public virtual ShopOrder ShopOrder { get; set; }
    }
}
