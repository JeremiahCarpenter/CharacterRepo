using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BookBO
    {
        public int BookID { get; set; }

        [Required(ErrorMessage = "Please enter the Author's name.")]
        [StringLength(100, ErrorMessage = "The author's name must be no more than {1} characters")]
        public string Title { get; set; }

        public int SeriesID_FK { get; set; }

        // Default constructor required to be able to use the mapping constructor below
        public BookBO()
        {

        }

        // Constructor to map the DataAccessLayer object to the BusinessLogicLayer object
        public BookBO(BookDO _bookDO)
        {
            BookID = _bookDO.BookID;
            Title = _bookDO.Title;
            SeriesID_FK = _bookDO.SeriesID_FK;
        }
    }
}
