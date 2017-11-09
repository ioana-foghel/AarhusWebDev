using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AarhusWebDevCoop.ViewModels
{
    public class ContactForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "This is not a valid email address!")]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Message { get; set; }
    }
}