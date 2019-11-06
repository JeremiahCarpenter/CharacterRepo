using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class UserBO
    {
        public int UserID { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="Please enter the user's first name.")]
        [StringLength(50, ErrorMessage = "The First Name must be no more than {1} characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter the user's last name.")]
        [StringLength(50, ErrorMessage = "The Last Name must be no more than {1} characters")]
        public string LastName { get; set; }

        [Display(Name ="Username")]
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(50, ErrorMessage = "The Username must be no more than {1} characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(50, ErrorMessage = "The Password must be no more than {1} characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [StringLength(50, ErrorMessage = "The Password must be no more than {1} characters")]
        public string EmailAddress { get; set; }


        public int RoleID_FK { get; set; }

        // Default constructor required to be able to use the mapping constructor below
        public UserBO()
        {

        }

        // Constructor to map a DataAccessLayer object to a BusinessLogicLayer object
        public UserBO(UserDO _userdo)
        {
            UserID = _userdo.UserID;
            FirstName = _userdo.FirstName;
            LastName = _userdo.LastName;
            UserName = _userdo.UserName;
            Password = _userdo.Password;
            EmailAddress = _userdo.EmailAddress;
            RoleID_FK = _userdo.RoleID_FK;
        }
    }
}
