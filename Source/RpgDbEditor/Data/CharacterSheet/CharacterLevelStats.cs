using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// Contains the values of base character stats in a specific level for a 
    /// specific character class.
    /// </summary>
    public class CharacterLevelStats
    {
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public int Level
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the strength property in this level.
        /// </summary>
        public int Strength
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the dexterity property in this level.
        /// </summary>
        public int Dexterity
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the wisdom property in this level.
        /// </summary>
        public int Wisdom
        {
            get;
            set;
        }
    }
}
