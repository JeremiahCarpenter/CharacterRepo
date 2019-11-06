using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharacterRepo.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(50, ErrorMessage = "The Username must be no more than {1} characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(50, ErrorMessage = "The Password must be no more than {1} characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }
        public string ReturnURL { get; set; }
    }
}