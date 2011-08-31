using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Ability
{
    /// <summary>
    /// Different type of target selection for an ability.
    /// </summary>
    public enum AbilityTargetSelectionTypes
    {
        /// <summary>
        /// The ability targets the user and doesn't need target selection.
        /// </summary>
        Self,

        /// <summary>
        /// The ability needs another character as target.
        /// </summary>
        AnotherCharacter,

        /// <summary>
        /// The ability needs a position in the world as target.
        /// </summary>
        Position,
    }
}
