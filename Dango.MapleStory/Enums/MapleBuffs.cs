namespace Dango.MapleStory.Enums
{
    public enum MapleBuffs : long
    {
        /// <summary>
        /// 变形
        /// </summary>
        Morph = 0x2,

        /// <summary>
        /// 恢复
        /// </summary>
        Recovery = 0x4,

        /// <summary>
        /// 冒险岛勇士
        /// </summary>
        MapleWarrior = 0x8,
        Stance = 0x10,

        /// <summary>
        /// 火眼金睛 - 赋予组队成员针对敌人寻找弱点并给予敌人致命伤的能力
        /// </summary>
        SharpEyes = 0x20,

        /// <summary>
        /// 魔法反击
        /// </summary>
        ManaReflection = 0x40,

        /// <summary>
        /// 暗器伤人
        /// </summary>
        ShadowClaw = 0x100,

        /// <summary>
        /// 终极无限 - 一定时间内搜集周围的魔力,不消耗魔法值
        /// </summary>
        Infinity = 0x20_0000_0000_0000L,

        /// <summary>
        /// 圣灵之盾
        /// </summary>
        HolyShield = 0x400,
        Hamstring = 0x800,
        Blind = 0x1000,
        Concentrate = 0x2000, // another no op buff
        EchoOfHero = 0x8000,
        GhostMorph = 0x2_0000, // ??? Morphs you into a ghost - no idea what for
        Dash = 0x6000_0000, //0x60000000
        BerserkFury = 0x800_0000,
        EnergyCharge = 0x8_0000_0000L,
        MonsterRiding = 0x100_0000_0000L,
        Watk = 0x1_0000_0000L,
        Wdef = 0x2_0000_0000L,
        Matk = 0x4_0000_0000L,
        Mdef = 0x8_0000_0000L,
        Acc = 0x10_0000_0000L,
        Avoid = 0x20_0000_0000L,
        Hands = 0x40_0000_0000L,
        Speed = 0x80_0000_0000L,
        Jump = 0x100_0000_0000L,
        MagicGuard = 0x200_0000_0000L,
        Darksight = 0x400_0000_0000L, // also used by gm hide
        Booster = 0x800_0000_0000L,
        SpeedInfusion = 0x8000_0000_0000L,
        Powerguard = 0x1000_0000_0000L,
        Hyperbodyhp = 0x2000_0000_0000L,
        Hyperbodymp = 0x4000_0000_0000L,
        Invincible = 0x8000_0000_0000L,
        Soularrow = 0x1_0000_0000_0000L,
        Stun = 0x2_0000_0000_0000L,
        Poison = 0x4_0000_0000_0000L,
        Seal = 0x8_0000_0000_0000L,
        Darkness = 0x10_0000_0000_0000L,
        Combo = 0x20_0000_0000_0000L,
        Summon = 0x20_0000_0000_0000L, //hack buffstat for summons ^.- =does/should not increase damage... hopefully <3
        WkCharge = 0x40_0000_0000_0000L,
        Dragonblood = 0x80_0000_0000_0000L, // another funny buffstat...
        HolySymbol = 0x100_0000_0000_0000L,
        Mesoup = 0x200_0000_0000_0000L,
        Shadowpartner = 0x400_0000_0000_0000L,

        //0x8000000000000
        Pickpocket = 0x800_0000_0000_0000L,
        Puppet = 0x800_0000_0000_0000L, // HACK - shares buffmask with pickpocket - odin special ^.-
        Mesoguard = 0x1000_0000_0000_0000L,
        Weaken = 0x4000_0000_0000_0000L //SWITCH_CONTROLS=0x8000000000000L
    }
}