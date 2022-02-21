using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Shared.Domain
{
    public class Category : IValidatableObject
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryNAME { get; set; }
        [Required]
        public string Description { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if(CategoryNAME ==null)
                yield return new ValidationResult("Please Input a Category", new[] { "CategoryNAME" });
            else if (Description == null)
                yield return new ValidationResult("Please Input a Description", new[] { "Description" });

        }
    }
}
