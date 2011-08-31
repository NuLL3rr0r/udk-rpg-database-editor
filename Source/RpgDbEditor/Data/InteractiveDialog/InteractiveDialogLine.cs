using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.InteractiveDialog
{
    /// <summary>
    /// Contains information about a single line of interactive dialog.
    /// </summary>
    public class InteractiveDialogLine
    {
        /// <summary>
        /// Gets or sets the unique ID of this dialog line.
        /// </summary>
        public string Id
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the character that speaks this dialog line.
        /// </summary>
        public string SpeakingCharacterId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the actual text of this dialog line.
        /// </summary>
        public string Text
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the condition that needs to be satisfied for this line to be available for playback.
        /// </summary>
        public DataCondition Condition
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets all of the actions that will be executed when this line is played.
        /// </summary>
        public List<DataAction> Actions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the designer comments about this dialog line.
        /// </summary>
        public string Comments
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the playback duration of this line in seconds.
        /// </summary>
        public float Duration
        {
            get;
            set;
        }


        /// <summary>
        /// Updates the properties that are derived from other properties of this dialog line.
        /// </summary>
        /// <param name="characterId">The ID of the character that this dialog line belongs to.</param>
        /// <param name="categoryString">The string that represents the 
        /// category that this line belongs to.</param>
        /// <param name="lineNumber">The line number in excel file.</param>
        internal void UpdateProperties(string characterId, string categoryString, int lineNumber)
        {
            // create the ID
            Id = string.Format("{0}_{1}_{2:00000}", characterId, categoryString, lineNumber).Trim().ToUpper();

            // TODO: check speech bank for actual audio length
            Duration = 0.3f + 0.1f * Text.Length;
        }

    }
}
