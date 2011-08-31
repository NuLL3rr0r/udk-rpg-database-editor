using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// Contains the relations between each main character properties and the actual stats.
    /// </summary>
    public class CharacterStatsRelations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterStatsRelations"/> class.
        /// </summary>
        public CharacterStatsRelations()
        {
            StrengthRelationships = new List<CharacterStatCoefficient>();
            DexterityRelationships = new List<CharacterStatCoefficient>();
            WisdomRelationships = new List<CharacterStatCoefficient>();
        }


        /// <summary>
        /// Gets or sets the relationships that strength property has with other stats.
        /// </summary>
        public List<CharacterStatCoefficient> StrengthRelationships
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the relationships that dexterty property has with other stats.
        /// </summary>
        public List<CharacterStatCoefficient> DexterityRelationships
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the relationships that wisdom property has with other stats.
        /// </summary>
        public List<CharacterStatCoefficient> WisdomRelationships
        {
            get;
            set;
        }

    }
}
