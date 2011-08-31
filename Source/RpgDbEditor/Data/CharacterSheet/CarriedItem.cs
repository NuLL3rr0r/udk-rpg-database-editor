using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// properties of a single item that is carried by a character.
    /// </summary>
    public class CarriedItem
    {
        /// <summary>
        /// Gets or sets the ID of the item.
        /// </summary>
        public string ItemId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the chance of this item being a looted by player (between 0 and 1).
        /// </summary>
        public float LootChance
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether this item is equipped by 
        /// the carrying character or not.
        /// </summary>
        public bool IsEquipped
        {
            get;
            set;
        }


        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            Database.ValidateItemId(ItemId);
        }
    }
}
