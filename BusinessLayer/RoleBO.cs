using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class RoleBO
    {
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Please enter the Class name.")]
        [StringLength(50, ErrorMessage = "The class name must be no more than {1} characters")]
        public string Role { get; set; }

        // Default constructor required to be able to use the mapping constructor below
        public RoleBO()
        {

        }

        // Constructor to map a DataAccessLayer object to a BusinessLogicLayer object
        public RoleBO(RoleDO _roleDO)
        {
            RoleID = _roleDO.RoleID;
            Role = _roleDO.Role;
        }
    }
}
