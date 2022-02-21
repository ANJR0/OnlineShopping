using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Shared.Domain
{
    public class Staff
    {
        public int StaffID { get; set; }
        [Required]
        public string StaffName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string StaffPASSWORD { get; set; }
        [Required]
        public string StaffEMAIL { get; set; }
    }
}
