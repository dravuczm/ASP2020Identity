using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp2020Identity.Models
{
    public class SiteUser : IdentityUser
    {
        [StringLength(60)]
        [Required]
        [Display(Name = "Vezetéknév")]
        public string FirstName { get; set; }

        [StringLength(60)]
        [Required]
        [Display(Name = "Keresztnév")]
        public string LastName { get; set; }
    }
}
