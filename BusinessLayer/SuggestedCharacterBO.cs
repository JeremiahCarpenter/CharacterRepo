using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class SuggestedCharacterBO
    {
        public int SuggestedCharacterID { get; set; }

        [Display(Name = "Suggested Character")]
        [Required(ErrorMessage = "Please enter the Suggested Character Name.")]
        [StringLength(50, ErrorMessage = "The name must be no more than {1} characters")]
        public string SuggestedCharacterName { get; set; }

        [Display(Name = "Suggested Character Series")]
        [Required(ErrorMessage = "Please enter the Series name.")]
        [StringLength(50, ErrorMessage = "The series name must be no more than {1} characters")]
        public string SuggestedCharacterSeries { get; set; }

        // Default constructor required to be able to use the mapping constructor below
        public SuggestedCharacterBO()
        {

        }

        // Constructor to map a DataAccessLayer object to a BusinessLogicLayer object
        public SuggestedCharacterBO(SuggestedCharacterDO _suggestedCharacterDO)
        {
            SuggestedCharacterID = _suggestedCharacterDO.SuggestedCharacterID;
            SuggestedCharacterName = _suggestedCharacterDO.SuggestedCharacterName;
            SuggestedCharacterSeries = _suggestedCharacterDO.SuggestedCharacterSeries;
        }
    }
}
