using System;


namespace Server 
{
    #region Enums
    [Flags]
    public enum StatType
    {
        Str = 1,
        Dex = 2,
        Int = 4,
        All = 7
    }

    public enum StatLockType : byte
    {
        Up,
        Down,
        Locked
    }

    [CustomEnum(new string[] { "North", "Right", "East", "Down", "South", "Left", "West", "Up" })]
    public enum Direction : byte
    {
        North = 0x0,
        Right = 0x1,
        East = 0x2,
        Down = 0x3,
        South = 0x4,
        Left = 0x5,
        West = 0x6,
        Up = 0x7,

        Mask = 0x7,
        Running = 0x80,
        ValueMask = 0x87
    }

    [Flags]
    public enum MobileDelta
    {
        None = 0x00000000,
        Name = 0x00000001,
        Flags = 0x00000002,
        Hits = 0x00000004,
        Mana = 0x00000008,
        Stam = 0x00000010,
        Stat = 0x00000020,
        Noto = 0x00000040,
        Gold = 0x00000080,
        Weight = 0x00000100,
        Direction = 0x00000200,
        Hue = 0x00000400,
        Body = 0x00000800,
        Armor = 0x00001000,
        StatCap = 0x00002000,
        GhostUpdate = 0x00004000,
        Followers = 0x00008000,
        Properties = 0x00010000,
        TithingPoints = 0x00020000,
        Resistances = 0x00040000,
        WeaponDamage = 0x00080000,
        Hair = 0x00100000,
        FacialHair = 0x00200000,
        Race = 0x00400000,
        HealthbarYellow = 0x00800000,
        HealthbarPoison = 0x01000000,

        Attributes = 0x0000001C
    }

    public enum AccessLevel
    {
        Player,
        Counselor,
        GameMaster,
        Seer,
        Administrator,
        Developer,
        Owner
    }

    public enum VisibleDamageType
    {
        None,
        Related,
        Everyone
    }

    public enum ResistanceType
    {
        Physical,
        Fire,
        Cold,
        Poison,
        Energy
    }

    public enum ApplyPoisonResult
    {
        Poisoned,
        Immune,
        HigherPoisonActive,
        Cured
    }
    #endregion
}
