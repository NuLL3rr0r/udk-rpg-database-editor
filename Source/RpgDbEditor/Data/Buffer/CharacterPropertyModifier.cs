using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Buffer
{
    /// <summary>
    /// Defines a modifier that changes a single property of a character.
    /// </summary>
    public class CharacterPropertyModifier
    {
        /// <summary>
        /// Gets or sets the type of this modifier.
        /// </summary>
        public CharacterPropertyModifierTypes ModifierType
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or set the value that this modifier (absolute or percentage).
        /// </summary>
        public float Value
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating that the value of this modifier is 
        /// stated in percentage not absolute.
        /// </summary>
        public bool IsPercentage
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether the change is applied once 
        /// (e.g. lowering the speed) or over time (healing).
        /// </summary>
        public bool IsAppliedOverTime
        {
            get;
            set;
        }


        /// <summary>
        /// Parses the a modifier object from the given text.
        /// </summary>
        /// <param name="modifierText">The text to parse.</param>
        /// <returns>The parse object.</returns>
        internal static CharacterPropertyModifier Parse(string modifierText)
        {
            throw new NotImplementedException();
        }
    }
}
