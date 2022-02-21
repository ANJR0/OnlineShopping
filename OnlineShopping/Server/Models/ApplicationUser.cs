using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace OnlineShopping.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

    
        public ApplicationUser(ApplicationUser AppUser)
        {
            this.Id = AppUser.Id;
            this.FirstName = AppUser.FirstName;
            this.LastName = AppUser.LastName;
            this.PhoneNumber = AppUser.PhoneNumber;
            this.NormalizedEmail = AppUser.NormalizedEmail;
            this.Email = AppUser.Email;
            this.NormalizedUserName = AppUser.NormalizedUserName;
            this.UserName = AppUser.UserName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
