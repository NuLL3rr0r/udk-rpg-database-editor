using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Buffer
{
    /// <summary>
    /// Different type of stacking behavior of a buff.
    /// </summary>
    public enum BufferStakingBehaviorTypes
    {
        /// <summary>
        /// Normal behavior, it will stack with other buffs.
        /// </summary>
        Normal,

        /// <summary>
        /// This buff will only stacked once. This means only one instance of 
        /// this buff can be stacked on a character at any time (new buff will 
        /// replace the old one).
        /// </summary>
        OnlyOnce,

        /// <summary>
        /// This buff will eliminate all other buffs on character.
        /// </summary>
        Debuff,
    }
}
