using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopping.Shared.Domain;

namespace OnlineShopping.Server.Configurations.Entities
{
    public class CategorySeedConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryNAME = "Clothes",
                    Description = " Causal and Fashion"

                }
                );
            
        }
    }
}
