using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusinessLayer
{
    public class CharacterBO
    {       
        
        public int CharacterID { get; set; }

        [Required(ErrorMessage = "Please enter the Character's name.")]
        [StringLength(50, ErrorMessage = "The character's name must be no more than {1} characters")]
        public string Name { get; set; }

        public string Class { get; set; }

        [Display(Name = "Armor Class")]
        [Required(ErrorMessage = "The {0} stat is required")]
        public int AC { get; set; }

        [Range(3, 25, ErrorMessage = "Character Stats must be between {1} and {2}")]
        [Required(ErrorMessage ="The {0} stat is required")]
        public int Strength { get; set; }

        [Range(3, 25, ErrorMessage = "Character Stats must be between {1} and {2}")]
        [Required(ErrorMessage = "The {0} stat is required")]
        public int Dexterity { get; set; }

        [Range(3, 25, ErrorMessage = "Character Stats must be between {1} and {2}")]
        [Required(ErrorMessage = "The {0} stat is required")]
        public int Constitution { get; set; }

        [Range(3, 25, ErrorMessage = "Character Stats must be between {1} and {2}")]
        [Required(ErrorMessage = "The {0} stat is required")]
        public int Intelligence { get; set; }

        [Range(3, 25, ErrorMessage = "Character Stats must be between {1} and {2}")]
        [Required(ErrorMessage = "The {0} stat is required")]
        public int Wisdom { get; set; }

        [Range(3, 25, ErrorMessage = "Character Stats must be between {1} and {2}")]
        [Required(ErrorMessage = "The {0} stat is required")]
        public int Charisma { get; set; }

        [Required(ErrorMessage = "A {0} must be provided")]
        [StringLength(8000, ErrorMessage = "The Description must not be more than {1} characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int SeriesID_FK { get; set; }        

        // Default constructor required to be able to use the mapping constructor below
        public CharacterBO()
        {

        }

        // Constructor to map a DataAccessLayer object to a BusinessLogicLayer object
        public CharacterBO(CharacterDO _characterDO)
        {
            CharacterID = _characterDO.CharacterID;
            Name = _characterDO.Name;
            Class = _characterDO.Class;
            AC = _characterDO.AC;
            Strength = _characterDO.Strength;
            Dexterity = _characterDO.Dexterity;
            Constitution = _characterDO.Constitution;
            Intelligence = _characterDO.Intelligence;
            Wisdom = _characterDO.Wisdom;
            Charisma = _characterDO.Charisma;
            Description = _characterDO.Description;
            SeriesID_FK = _characterDO.SeriesID_FK;            
        }

    }
}
