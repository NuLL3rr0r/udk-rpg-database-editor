using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Buffer
{
    /// <summary>
    /// Contains properties of a single damage that can be caused by a buff.
    /// </summary>
    public class BufferDamage
    {
        /// <summary>
        /// Gets or sets the type of damage.
        /// </summary>
        public DamageType DamageType
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the minimum amount of damage.
        /// </summary>
        public float DamageMinAmount
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the maximum amount of damage.
        /// </summary>
        public float DamageMaxAmount
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or set the chance of critical damage (between 0 and 1).
        /// </summary>
        public float CriticalDamageChance
        {
            get;
            set;
        }


        const char CriticalChanceChar = '%';
        const char RangeChar = '-';
        const string PhysicalDmageChar = "P";
        const string MagicalDmageChar = "M";
        const string SonicDmageChar = "S";

    }
}
