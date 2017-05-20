using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain
{
    public enum CardType
    {
        Character,
        Upgrade,
        Support,
        Event,
        Battlefield
    }

    public enum Symbol
    {
        Blank,
        Discard,
        Disrupt,
        Focus,
        MeleeDamage,
        RangedDamage,
        Resource,
        Shield,
        Special
    }

    public enum Modifier
    {
        Plus
    }

    public enum Affiliation
    {
        Hero,
        Villian,
        Neutral
    }

    public enum Faction
    {
        /// <summary>
        /// Blue
        /// </summary>
        Force,
        /// <summary>
        /// Red
        /// </summary>
        Command,
        /// <summary>
        /// Yellow
        /// </summary>
        Rogue,
        /// <summary>
        /// Gray
        /// </summary>
        Neutral
    }

    public enum SubType
    {
        Vehicle,
        Weapon,
        Ability,
        Equipment,
        Droid
    }
}
