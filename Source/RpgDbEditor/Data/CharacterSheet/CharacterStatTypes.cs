using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.CharacterSheet
{
    /// <summary>
    /// Different types of simple properties of a character.
    /// </summary>
    public enum CharacterStatTypes
    {
        HP,
        HPRegeneration,
        Energy,
        EnergyRegeneration,
        Mana,
        ManaRegeneration,
        Shur,
        ShurRegeneration,
        PhysicalDamage,
        PhysicalResistance,
        MagicalDamage,
        MagicalResistance,
        SonicDamage,
        SonicResistance,
    }
}
