using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class ClassBO
    {
        public int ClassID { get; set; }

        [Required(ErrorMessage = "Please enter the Classname.")]
        [StringLength(50, ErrorMessage = "The classname must be no more than {1} characters")]
        public string ClassName { get; set; }

        [Required]
        public int ClassDiceValue { get; set; }

        // Default constructor required to be able to use the mapping constructor below
        public ClassBO()
        {

        }

        // Constructor to map a DataAccessLayer object to a BusinessLogicLayer object
        public ClassBO(ClassDO _classDO)
        {
            ClassID = _classDO.ClassID;
            ClassName = _classDO.ClassName;
            ClassDiceValue = _classDO.ClassDiceValue;
        }
    }
}
