using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class SeriesBO
    {
        public int SeriesID { get; set; }

        [Display(Name = "Series Title")]
        [Required(ErrorMessage = "Please enter the series title.")]
        [StringLength(50, ErrorMessage = "The Series Title must be no more than {1} characters")]
        public string SeriesTitle { get; set; }

        public int AuthorID_FK { get; set; }

        // Default constructor required to be able to use the mapping constructor below
        public SeriesBO()
        {

        }

        // Constructor to map a DataAccessLayer object to a BusinessLogicLayer object
        public SeriesBO(SeriesDO _seriesDO)
        {
            SeriesID = _seriesDO.SeriesID;
            SeriesTitle = _seriesDO.SeriesTitle;
            AuthorID_FK = _seriesDO.AuthorID_FK;
        }
    }
}
