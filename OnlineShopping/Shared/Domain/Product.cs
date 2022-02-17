using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Shared.Domain
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductNAME { get; set; }
        public string ProductPRICE { get; set; }
        public string Description { get; set; }
        public string Stocks { get; set; }
        public int CatergoryID { get; set; }
        public virtual Category Category { get; set; }
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
