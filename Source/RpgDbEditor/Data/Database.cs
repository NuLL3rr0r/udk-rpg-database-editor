using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using RpgDatabaseParser.Data.InteractiveDialog;
using RpgDatabaseParser.Data.CharacterSheet;
using RpgDatabaseParser.Data.Buffer;
using RpgDatabaseParser.Data.Ability;
using RpgDatabaseParser.Data.Quest;

namespace RpgDatabaseParser.Data
{
    /// <summary>
    /// Defines the entire database's structure.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Database()
        {
            this.InteractiveDialogList = new List<InteractiveDialogPackage>();
            this.GlobalCharacterProperties = new GlobalCharacterProperties();
            this.CharacterDefinitions = new List<CharacterDefinition>();
            this.AbilityDefinitions = new List<AbilityDefinition>();
            this.BufferDefinitions = new List<BufferDefinition>();
            this.QuestDefinitions = new List<QuestDefinition>();

            this.FileVersion = new Version(0, 1).ToString();
        }


        #region Validations

        public static void ValidateCharacterId(string characterId)
        {
        }


        public static void ValidateItemId(string itemId)
        {
        }


        public static void ValidateQuestId(string questId)
        {
        }


        public static void ValidateShopId(string characterId)
        {
        }


        public static void ValidateAbilityId(string id)
        {
        }


        public static void ValidateQuestId(int id)
        {
        }


        public static bool IsPlayerCharacterId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;
            return string.Compare(id, "PLAYER", true) == 0;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the file version of this database object.
        /// </summary>
        public string FileVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of interactive dialog.
        /// </summary>
        public List<InteractiveDialogPackage> InteractiveDialogList
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the global character properties.
        /// </summary>
        public GlobalCharacterProperties GlobalCharacterProperties
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all character definitions.
        /// </summary>
        public List<CharacterDefinition> CharacterDefinitions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all ability definitions.
        /// </summary>
        public List<AbilityDefinition> AbilityDefinitions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all buffer definitions.
        /// </summary>
        public List<BufferDefinition> BufferDefinitions
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of all quest definitions.
        /// </summary>
        public List<QuestDefinition> QuestDefinitions
        {
            get;
            set;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets the interactive dialog for a character.
        /// </summary>
        /// <param name="characterId">Character ID.</param>
        /// <returns></returns>
        public InteractiveDialogPackage GetInteractiveDialogForCharacter(string characterId)
        {
            // find if there's already a record for this character
            foreach (InteractiveDialogPackage d in InteractiveDialogList)
            {
                if (string.Compare(d.CharacterId, characterId, true) == 0)
                {
                    return d;
                }
            }

            // create new
            InteractiveDialogPackage newDialog = new InteractiveDialogPackage();
            newDialog.CharacterId = characterId;
            InteractiveDialogList.Add(newDialog);
            return newDialog;
        }


        /// <summary>
        /// Saves this database to a XML file.
        /// </summary>
        /// <param name="fileName">The path to output file.</param>
        public void SaveToFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Database));
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                serializer.Serialize(writer, this);
            }
        }

        #endregion

    }
}
