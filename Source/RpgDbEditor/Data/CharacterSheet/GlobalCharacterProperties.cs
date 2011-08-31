using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// Contains properties that is shared between all character classes.
    /// </summary>
    public class GlobalCharacterProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalCharacterProperties"/> class.
        /// </summary>
        public GlobalCharacterProperties()
        {
            CharacterClasses = new List<CharacterClassDefinition>();
            CharacterStatsRelations = new CharacterStatsRelations();
            ExperienceTable = new List<CharacterLevel>();
        }


        /// <summary>
        /// Gets or sets the difinitions of all character classes.
        /// </summary>
        public List<CharacterClassDefinition> CharacterClasses
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the relations between different character stats.
        /// </summary>
        public CharacterStatsRelations CharacterStatsRelations
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of the levels and the needed experience for each.
        /// </summary>
        public List<CharacterLevel> ExperienceTable
        {
            get;
            set;
        }


    }
}
