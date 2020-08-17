using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyTasty.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyTasty.Data
{
    public class HealthyTastyDbContext : IdentityDbContext<HealthyTastyUser>
    {
        public HealthyTastyDbContext(DbContextOptions<HealthyTastyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<HealthyTastyUser>().ToTable("Users");
            builder.Entity<HealthyTastyUser>().Ignore(c => c.AccessFailedCount)
                                          .Ignore(c => c.ConcurrencyStamp)
                                          .Ignore(c => c.LockoutEnd)
                                          .Ignore(c => c.PhoneNumber)
                                          .Ignore(c => c.LockoutEnabled)
                                          .Ignore(c => c.NormalizedEmail)
                                          .Ignore(c => c.NormalizedUserName)
                                          .Ignore(c => c.PhoneNumberConfirmed)
                                          .Ignore(c => c.SecurityStamp)
                                          .Ignore(c => c.TwoFactorEnabled)
                                          .Ignore(c => c.UserName);


            builder.Entity<IdentityRole>().ToTable("Roles")
                                          .Ignore(c => c.ConcurrencyStamp)
                                          .Ignore(c => c.NormalizedName);
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();


        }
    }
}
