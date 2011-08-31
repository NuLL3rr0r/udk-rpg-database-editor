using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Quest
{
    /// <summary>
    /// Different categories of quests.
    /// </summary>
    public enum QuestCategories
    {
        /// <summary>
        /// A main quest.
        /// </summary>
        Main,

        /// <summary>
        /// A side quest.
        /// </summary>
        Side,

        /// <summary>
        /// A sub quest (a part of a side or main quest).
        /// </summary>
        Sub,
    }
}
