using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Shared.Domain
{
    public class Delivery
    {
        public int DeliveryID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDATE { get; set; }
        [Required]
        public int? StaffID { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
