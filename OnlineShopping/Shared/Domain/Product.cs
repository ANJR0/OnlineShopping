using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Shared.Domain
{
    public class Product : IValidatableObject
    {
        public int ProductID { get; set; }
        [Required]
        public string ProductNAME { get; set; }
        [Required]
        public string ProductPRICE { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Stocks { get; set; }
        [Required]
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public int? BrandID { get; set; }
        public virtual Brand Brand { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Category == null)
                yield return new ValidationResult("Please Input a CategoryID", new[] { "CategoryID" });
            if (Brand == null)
                yield return new ValidationResult("Please Input a BrandID", new[] { "BrandID" });

        }
    }
}
