using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShopping.Server.Configurations.Entities
{
    public class CustomerSeedConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    CustomerID = 1,
                    Email = "blabla@gmail.com",
                    Password = "hello12345",
                    Full_name = "Melvin Lee",
                    Billing_address = "555A Lakeside",
                    Country = "Singapore",
                    Phone = "93434383",
                    Default_shipping_address = "555A Lakeside"
                }
                );
        }
    }
}
