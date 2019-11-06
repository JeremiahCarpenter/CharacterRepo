﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserCharacterDO
    {
        public int UserCharacterID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int ClassLevel { get; set; }
        public int HitPoints { get; set; }
        public int AC { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public string Description { get; set; }
        public int SeriesID_FK { get; set; }        
        public int UserID_FK { get; set; }
    }
}
