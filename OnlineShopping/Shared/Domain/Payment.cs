using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Shared.Domain
{
    public class Payment
    {
        public int PaymentID { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Datetime { get; set; }
        [Required]
        public int? ShopOrderID { get; set; }
        public virtual ShopOrder ShopOrder { get; set; }
    }
}
