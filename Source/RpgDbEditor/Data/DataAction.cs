using System.Collections.Generic;
using System.Globalization;

namespace RpgDatabaseParser.Data
{
    /// <summary>
    /// Defines an action used in database.
    /// </summary>
    public class DataAction
    {
        /// <summary>
        /// Gets or sets the type of this action.
        /// </summary>
        public ActionTypes ActionType
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or set the argument of the action as a string.
        /// </summary>
        public string StringArgument
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or set the argument of the action as a integer.
        /// </summary>
        public int NumberArgument
        {
            get;
            set;
        }



        /// <summary>
        /// Different kinds of actions.
        /// </summary>
        public enum ActionTypes
        {
            AddItem,
            RemoveItem,
            AddMoney,
            RemoveMoney,
            OpenQuest,
            CloseQuest,
            OpenShop,
            AddXP,
            RunKismet,
            MakeEnemy,
        }


    }
}
