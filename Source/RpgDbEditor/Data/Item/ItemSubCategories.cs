using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Item
{
    /// <summary>
    /// Different sub-categories for items.
    /// </summary>
    public enum ItemSubCategories
    {
        // weapon
        LightWeapon,
        HeavyWeapon,
        Flail,

        Wand,
        Staff,

        WindInstrument,
        StringInstrument,
        PercussionInstrument,
        Dagger,

        // armor
        BodyVest,
        Gloves,
        Belt,
        Shoes,
        Necklace,
        Ring,

        // consumable
        Potion,
        Bomb,
        Scroll,

        // quest
        MainQuest,
        SubQuest,

        // misc
        Book,
        Ingredient,
        Commodity,

    }
}
