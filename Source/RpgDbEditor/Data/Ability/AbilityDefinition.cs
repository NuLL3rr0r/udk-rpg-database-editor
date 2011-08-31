using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Ability
{
    /// <summary>
    /// Contains definition of a single ability.
    /// </summary>
    public class AbilityDefinition
    {
        /// <summary>
        /// Gets or sets the unique ID of this ability.
        /// </summary>
        public string Id
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the name of this ability.
        /// </summary>
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the description of this ability.
        /// </summary>
        public string Description
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the level of this ability.
        /// </summary>
        public int Level
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the ID of the next level ability.
        /// </summary>
        public string NextLevelAbilityId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the minumum character level that can use this ability.
        /// </summary>
        public int NeededCharacterLevel
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the needed mana for performing this ability.
        /// </summary>
        public int NeededMana
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the ID of the item (if any) that is needed for performing this ability.
        /// </summary>
        public string NeededItemId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the time in seconds this ability needs to cooldown after a use.
        /// </summary>
        public float CooldownTime
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the target selection type of this ability.
        /// </summary>
        public AbilityTargetSelectionTypes TargetSelectionType
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the maximum range of this ability in meters.
        /// Zero means melee range.
        /// </summary>
        public float Range
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the area around the target (in meters) that this 
        /// ability will affect.
        /// Zero means only the target will take the effect of this ability. If 
        /// target selection is "Position" this value must be greater than zero.
        /// </summary>
        public float EffectiveArea
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of buffers that this ability releases on user when used.
        /// </summary>
        public List<string> SelfBuffers
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of buffers that this ability releases on friends when used.
        /// </summary>
        public List<string> FriendsBuffers
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of buffers that this ability releases on enemies when used.
        /// </summary>
        public List<string> EnemiesBuffers
        {
            get;
            set;
        }

    }
}
