using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Item
{
    /// <summary>
    /// Contains properties of a single item.
    /// </summary>
    public class ItemDefinition
    {
        /// <summary>
        /// Gets or sets the unique ID of this item.
        /// </summary>
        public string Id
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the name of this item.
        /// </summary>
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the description for this item.
        /// </summary>
        public string Description
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the category of this item.
        /// </summary>
        public ItemCategories Category
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the sub-category of this item.
        /// </summary>
        public ItemSubCategories SubCategory
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of buffs this item releases when equipped or used (based on category).
        /// </summary>
        public List<string> Buffers
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of buffers that this ability releases on user when equipped or used (based on category).
        /// </summary>
        public List<string> SelfBuffers
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of buffers that this ability releases on friends when equipped or used (based on category).
        /// </summary>
        public List<string> FriendsBuffers
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of buffers that this ability releases on enemies when equipped or used (based on category).
        /// </summary>
        public List<string> EnemiesBuffers
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the area around the uesr (in meters) that this item 
        /// will affect when used or equipped.
        /// Zero means only the uesr will take the effect of this item. This 
        /// is mostly used for bombs and scrolls.
        /// </summary>
        public float EffectiveArea
        {
            get;
            set;
        }


    }
}
