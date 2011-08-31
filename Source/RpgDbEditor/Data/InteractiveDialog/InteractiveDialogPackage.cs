using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.InteractiveDialog
{
    /// <summary>
    /// Contains interactive dialog for a single character.
    /// </summary>
    public class InteractiveDialogPackage
    {
        public InteractiveDialogPackage()
        {
            GreetingDialogOptions = new List<InteractiveDialogLine>();
            InfoDialogBatches = new List<List<InteractiveDialogLine>>();
            InitiationDialogBatches = new List<List<InteractiveDialogLine>>();
            QuestDialogBatches = new List<List<InteractiveDialogLine>>();
            ShoppingDialog = new ShoppingInteractiveDialog();
            FarewellDialogOptions = new List<InteractiveDialogLine>();
        }


        
        /// <summary>
        /// Gets or sets the ID of the character that all these dialog lines belong to.
        /// </summary>
        public string CharacterId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all greeting dialog options.
        /// </summary>
        public List<InteractiveDialogLine> GreetingDialogOptions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all info dialog batches.
        /// </summary>
        public List<List<InteractiveDialogLine>> InfoDialogBatches
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all initiation dialog batches.
        /// </summary>
        public List<List<InteractiveDialogLine>> InitiationDialogBatches
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all quest dialog batches.
        /// </summary>
        public List<List<InteractiveDialogLine>> QuestDialogBatches
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the shopping dialog.
        /// </summary>
        public ShoppingInteractiveDialog ShoppingDialog
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all farewell dialog options.
        /// </summary>
        public List<InteractiveDialogLine> FarewellDialogOptions
        {
            get;
            set;
        }

    }
}
