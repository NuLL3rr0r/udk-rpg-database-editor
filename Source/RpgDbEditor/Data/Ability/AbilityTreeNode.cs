using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Ability
{
    /// <summary>
    /// A single node in ability tree.
    /// </summary>
    public class AbilityTreeNode
    {
        /// <summary>
        /// Gets or sets the ID of the ability in this node.
        /// </summary>
        public string AbilityId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the ID of the ability needed for this node to be available.
        /// </summary>
        public string PrequisitAbilityId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the default level of this ability.
        /// </summary>
        public int DefaultLevel
        {
            get;
            set;
        }


        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            Database.ValidateAbilityId(AbilityId);
            Database.ValidateAbilityId(PrequisitAbilityId);
        }

    }
}
