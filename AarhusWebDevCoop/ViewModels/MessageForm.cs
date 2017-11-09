using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AarhusWebDevCoop.ViewModels
{
    public class MessageForm
    {
        [Required]
        public string NameMessage { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string MessageContent { get; set; }
    }
}