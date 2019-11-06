using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class AuthorBO
    {
        public int AuthorID { get; set; }

        [Display(Name = "Authors Name")]
        [Required(ErrorMessage = "Please enter the author's name.")]
        [StringLength(100, ErrorMessage = "The Author's Name must be no more than {1} characters")]
        public string Name { get; set; }

        // Default constructor required to be able to use the mapping constructor below
        public AuthorBO()
        {

        }

        // Constructor to map a DataAccessLayer object to a BusinessLogicLayer object
        public AuthorBO(AuthorDO _authorDO)
        {
            AuthorID = _authorDO.AuthorID;
            Name = _authorDO.Name;
        }

        
    }
    
    
}
