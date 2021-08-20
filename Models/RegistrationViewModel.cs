using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace resume_MVC.Models
{
    public class RegistrationViewModel
    {

        [Required]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Address: ")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
    }
}