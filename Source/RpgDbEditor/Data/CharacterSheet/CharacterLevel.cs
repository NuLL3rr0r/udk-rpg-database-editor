using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// Contains definition for a single level in experience table.
    /// </summary>
    public class CharacterLevel
    {
        /// <summary>
        /// Gets or sets the needed experience to reach this level.
        /// </summary>
        public int Level
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the needed experience to reach this level.
        /// </summary>
        public int NeededExperience
        {
            get;
            set;
        }
    }
}
