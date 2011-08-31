using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// Contains all of properties of a single character.
    /// </summary>
    public class CharacterDefinition
    {
        /// <summary>
        /// Gets or sets the unique ID of the character.
        /// </summary>
        public string Id
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the name of this character.
        /// </summary>
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the class of a character.
        /// </summary>
        public CharacterClassTypes Class
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the initial level of the character.
        /// </summary>
        public int Level
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets all of the additional abilities that this specific character has.
        /// </summary>
        public List<string> AdditionalAbilities
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets all of the items that this character is carrying.
        /// </summary>
        public List<CarriedItem> CarriedItems
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the amount of XP gained from killing this character.
        /// </summary>
        public int XPGainedFromKill
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the minimum amount of money gained from killing this character.
        /// </summary>
        public int MinMoneyGainedFromKill
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the maximum amount of money gained from killing this character.
        /// </summary>
        public int MaxMoneyGainedFromKill
        {
            get;
            set;
        }


        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            Database.ValidateCharacterId(Id);
            if(AdditionalAbilities != null)
                foreach (string abilityId in AdditionalAbilities)
                    Database.ValidateAbilityId(abilityId);
            if (CarriedItems != null)
                foreach (CarriedItem item in CarriedItems)
                    item.Validate();
        }

    }
}
