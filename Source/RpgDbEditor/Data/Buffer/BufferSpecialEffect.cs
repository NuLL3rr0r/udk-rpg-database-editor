using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Buffer
{
    /// <summary>
    /// Contains properties of a single special effect for a buff.
    /// </summary>
    public class BufferSpecialEffect
    {
        /// <summary>
        /// Gets or sets the type of this special effect.
        /// </summary>
        public BufferSpecialEffectTypes EffectType
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the chance that this effect will be applied (between 0 and 1).
        /// </summary>
        public float Chance
        {
            get;
            set;
        }


        /// <summary>
        /// Parses the a special effect object given the text representaion of it.
        /// </summary>
        /// <param name="specialEffectText">The text to parse.</param>
        /// <returns>The parsed spcial effect object.</returns>
        internal static BufferSpecialEffect Parse(string specialEffectText)
        {
            throw new NotImplementedException();
        }
    }
}
