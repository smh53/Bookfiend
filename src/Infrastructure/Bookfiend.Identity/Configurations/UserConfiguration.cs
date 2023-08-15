using Bookfiend.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "semihtav@localhost.com",
                     NormalizedEmail = "SEMIHTAV@LOCALHOST.COM",
                     Firstname = "Semih",
                     Lastname = "Tavukçu",
                     UserName = "semihtav@localhost.com",
                     NormalizedUserName = "SEMIHTAV@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "test@localhost.com",
                     NormalizedEmail = "TEST@LOCALHOST.COM",
                     Firstname = "test",
                     Lastname = "test",
                     UserName = "test@localhost.com",
                     NormalizedUserName = "TEST@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}
