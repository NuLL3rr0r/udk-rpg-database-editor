using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// Defines the value added to a specific character stat by a main property.
    /// </summary>
    public class CharacterStatCoefficient
    {
        /// <summary>
        /// Gets or sets the stat that is being modified.
        /// </summary>
        public CharacterStatTypes StatType
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the value that is added to the stat.
        /// </summary>
        public int Value
        {
            get;
            set;
        }
    }
}
