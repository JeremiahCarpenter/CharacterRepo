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
    public class CharacterTransition
    {
        public int CharacterID { get; set; }

        [Required(ErrorMessage = "Please enter the Character's name.")]
        [StringLength(50, ErrorMessage = "The character's name must be no more than {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the Character's class.")]
        [StringLength(50, ErrorMessage = "The class must be no more than {1} characters")]
        public string Class { get; set; }

        [Display(Name = "Character Level")]
        [Range(3,20, ErrorMessage = "The Character must be between 3rd and 20th level.")]
        public int ClassLevel { get; set; }

        [Display(Name= "Armor Class")]
        public int AC { get; set; }

        [Range(3, 20, ErrorMessage = "Character Stats must be between 3 and 25")]
        public int Strength { get; set; }

        [Range(3, 20, ErrorMessage = "Character Stats must be between 3 and 25")]
        public int Dexterity { get; set; }

        [Range(3, 20, ErrorMessage = "Character Stats must be between 3 and 25")]
        public int Constitution { get; set; }

        [Range(3, 20, ErrorMessage = "Character Stats must be between 3 and 25")]
        public int Intelligence { get; set; }

        [Range(3, 20, ErrorMessage = "Character Stats must be between 3 and 25")]
        public int Wisdom { get; set; }

        [Range(3, 20, ErrorMessage = "Character Stats must be between 3 and 25")]
        public int Charisma { get; set; }

        [Required]
        [StringLength(4000, ErrorMessage = "The Description must not be more than {1} characters")]
        public string Description { get; set; }

        public int SeriesID_FK { get; set; }       

        public CharacterTransition()
        {

        }


        public CharacterTransition(CharacterBO character)
        {
            CharacterID = character.CharacterID;
            Name = character.Name;
            Class = character.Class;
            ClassLevel = 7;
            AC = character.AC;
            Strength = character.Strength;
            Dexterity = character.Dexterity;
            Constitution = character.Constitution;
            Intelligence = character.Intelligence;
            Wisdom = character.Wisdom;
            Charisma = character.Charisma;
            Description = character.Description;
            SeriesID_FK = character.SeriesID_FK;            
        }

    }

    
}
