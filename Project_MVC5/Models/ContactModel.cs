using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_MVC5.Models
{
    public class ContactModel
    {
        [Display(Name = "Name")]
        [Required (ErrorMessage ="Required")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Error")]
        public string Email { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Required")]
        public string Subject { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

    }
}