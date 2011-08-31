using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgDatabaseParser.Data.Ability;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// Contains the experience table and other properties of a certain calss.
    /// </summary>
    public class CharacterClassDefinition
    {
        public CharacterClassDefinition()
        {
            Stats = new List<CharacterLevelStats>();
        }


        /// <summary>
        /// Gets or sets the class that this table is for.
        /// </summary>
        public CharacterClassTypes Class
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the ability tree of this class.
        /// </summary>
        public AbilityTree AbilityTree
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all character stats in each level.
        /// </summary>
        public List<CharacterLevelStats> Stats
        {
            get;
            set;
        }

    }
}
