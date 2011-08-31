using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Ability
{
    /// <summary>
    /// Defines the ability tree of a character class.
    /// </summary>
    public class AbilityTree
    {
        /// <summary>
        /// Gets or sets all of the nodes in ability tree.
        /// </summary>
        public List<AbilityTreeNode> Nodes
        {
            get;
            set;
        }

    }
}
