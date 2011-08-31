using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.InteractiveDialog
{
    /// <summary>
    /// Contains interactive dialogs used for doing a trade with a NPC.
    /// </summary>
    public class ShoppingInteractiveDialog
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ShoppingInteractiveDialog()
        {
            OpenShopDialogBatch = new List<InteractiveDialogLine>();
            BuyDialogOptions = new List<InteractiveDialogLine>();
            SellDialogOptions = new List<InteractiveDialogLine>();
            DenyDialogOptions = new List<InteractiveDialogLine>();
        }


        /// <summary>
        /// Gets or sets the dialog batch used for openning the shop.
        /// </summary>
        public List<InteractiveDialogLine> OpenShopDialogBatch
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the dialogs options that are used when player buys something.
        /// </summary>
        public List<InteractiveDialogLine> BuyDialogOptions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the dialogs options that are used when player sells something.
        /// </summary>
        public List<InteractiveDialogLine> SellDialogOptions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the dialogs options that are used when player cannot sell something.
        /// </summary>
        public List<InteractiveDialogLine> DenyDialogOptions
        {
            get;
            set;
        }

    }
}
