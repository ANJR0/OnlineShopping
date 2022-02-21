using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Shared.Domain
{
    public class Brand : IValidatableObject
    {
        public int BrandID { get; set; }
        [Required]
        [StringLength(100,MinimumLength =1 , ErrorMessage = "A Brand Name is required")]
        public string BrandNAME { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(BrandNAME == null)
                yield return new ValidationResult("Please Input a Brand",new[] { "BrandNAME" });
            
        }
    }
}
