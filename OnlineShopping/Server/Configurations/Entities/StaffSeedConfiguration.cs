using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShopping.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    StaffID = 1,
                    StaffName = "Kalan",
                    Gender = "Female",
                    StaffPASSWORD = "Kalan12345",
                    StaffEMAIL = "Kalan@gmail.com"
                }
                );
        }
    }
}
