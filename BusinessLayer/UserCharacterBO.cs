using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class UserCharacterBO
    {
        public int UserCharacterID { get; set; }

        [Required(ErrorMessage = "Please enter the Character's name.")]
        [StringLength(50, ErrorMessage = "The character's name must be no more than {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the Character's class.")]
        [StringLength(50, ErrorMessage = "The class must be no more than {1} characters")]
        public string Class { get; set; }

        public int ClassLevel { get; set; }

        public int HitPoints { get; set; }

        [Display(Name = "Armor Class")]
        [Required(ErrorMessage = "The {0} stat is required")]
        public int AC { get; set; }

        [Range(3, 25, ErrorMessage = "Character Stats must be between {1} and {2}")]
        [Required(ErrorMessage = "The {0} stat is required")]
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
        [StringLength(4000, ErrorMessage = "The Description must not be more than {1} characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int SeriesID_FK { get; set; }  
        
        public int UserID_FK { get; set; }

        public UserCharacterBO()
        {

        }

        public UserCharacterBO(UserCharacterDO _userCharacterDO)
        {
            UserCharacterID = _userCharacterDO.UserCharacterID;
            Name = _userCharacterDO.Name;
            Class = _userCharacterDO.Class;
            ClassLevel = _userCharacterDO.ClassLevel;
            HitPoints = _userCharacterDO.HitPoints;
            AC = _userCharacterDO.AC;
            Strength = _userCharacterDO.Strength;
            Dexterity = _userCharacterDO.Dexterity;
            Constitution = _userCharacterDO.Constitution;
            Intelligence = _userCharacterDO.Intelligence;
            Wisdom = _userCharacterDO.Wisdom;
            Charisma = _userCharacterDO.Charisma;
            Description = _userCharacterDO.Description;
            SeriesID_FK = _userCharacterDO.SeriesID_FK;            
            UserID_FK = _userCharacterDO.UserID_FK;
        }
    }

    
}
