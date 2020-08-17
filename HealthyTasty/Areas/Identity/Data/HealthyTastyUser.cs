using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HealthyTasty.Areas.Identity.Data
{
    public enum Status
    {
        Pending,
        Active,
        Inactive,
        Deleted
    }
    // Add profile data for application users by adding properties to the HealthyTastyUser class
    public class HealthyTastyUser : IdentityUser
    {
        [Required]
        [PersonalData]
        [Column(TypeName="nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Required]
        public Status UserStatus { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
