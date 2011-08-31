using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Buffer
{
    /// <summary>
    /// Different types of special effects for a buff.
    /// </summary>
    public enum BufferSpecialEffectTypes
    {
        /// <summary>
        /// Character cannot move or do anything.
        /// </summary>
        Stun,

        /// <summary>
        /// Character will moving away from all enemies.
        /// </summary>
        Fear,

        /// <summary>
        /// Character cannot move but can perform other things. Bacause of this 
        /// character can only target other characters that are in range.
        /// </summary>
        Stuck,

        /// <summary>
        /// Character will be driven back until it's out of melee attack range.
        /// </summary>
        KnockBack,

        /// <summary>
        /// Character will be knocked down and will be able to stand up immediately after that.
        /// </summary>
        KnockDown,

    }
}
