using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace RpgDatabaseParser.Data
{
    /// <summary>
    /// Defines a condition used in database.
    /// </summary>
    public class DataCondition
    {
        /// <summary>
        /// Gets or sets the type of this condition.
        /// </summary>
        public ConditionTypes ConditionType
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or set the argument of the condition as a string.
        /// </summary>
        public string StringArgument
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or set the argument of the condition as a integer.
        /// </summary>
        public int NumberArgument
        {
            get;
            set;
        }



        /// <summary>
        /// Different kinds of conditions.
        /// </summary>
        public enum ConditionTypes
        {
            HasItem,
            HasMoney,
            QuestNotOpended,
            QuestOpened,
            QuestClosed,
        }

    }
}
