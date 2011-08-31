using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Quest
{
    /// <summary>
    /// Definition of a single quest.
    /// </summary>
    public class QuestDefinition
    {
        /// <summary>
        /// Gets or sets the ID of this quest.
        /// </summary>
        public int Id
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the category of this quest.
        /// </summary>
        public QuestCategories Category
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the index of the slot that this quest resides in journal page.
        /// </summary>
        public int SlotIndex
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of childrens of this quest.
        /// </summary>
        public List<int> Children
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the description of this quest.
        /// </summary>
        public string Description
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the conditions of this quest.
        /// </summary>
        public List<DataCondition> Conditions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the done conditions of this quest.
        /// </summary>
        public List<DataCondition> DoneConditions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the actions of this quest.
        /// </summary>
        public List<DataAction> Actions
        {
            get;
            set;
        }



        /// <summary>
        /// Validates this quest.
        /// </summary>
        internal void Validate()
        {
            Database.ValidateQuestId(Id);

        }
    }
}
