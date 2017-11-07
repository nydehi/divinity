using System;
using System.Collections.Generic;
using Server.Accounting;
using Server.ContextMenus;
using Server.Guilds;
using Server.Gumps;
using Server.HuePickers;
using Server.Items;
using Server.Menus;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Targeting;

namespace Server
{
    public interface IMobile
    {
        int CompareTo( IEntity other );
        int CompareTo( Mobile other );
        int CompareTo( object other );

        [CommandProperty(AccessLevel.GameMaster)]
        Race Race { get; set; }

        double RacialSkillBonus { get; }
        int[] Resistances { get; }
        int BasePhysicalResistance { get; }
        int BaseFireResistance { get; }
        int BaseColdResistance { get; }
        int BasePoisonResistance { get; }
        int BaseEnergyResistance { get; }

        [CommandProperty(AccessLevel.Counselor)]
        int PhysicalResistance { get; }

        [CommandProperty(AccessLevel.Counselor)]
        int FireResistance { get; }

        [CommandProperty(AccessLevel.Counselor)]
        int ColdResistance { get; }

        [CommandProperty(AccessLevel.Counselor)]
        int PoisonResistance { get; }

        [CommandProperty(AccessLevel.Counselor)]
        int EnergyResistance { get; }

        List<ResistanceMod> ResistanceMods { get; set; }
        bool NewGuildDisplay { get; }
        List<Mobile> Stabled { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        VirtueInfo Virtues { get; set; }

        object Party { get; set; }
        List<SkillMod> SkillMods { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        int VirtualArmorMod { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int MeleeDamageAbsorb { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int MagicDamageAbsorb { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int SkillsTotal { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        int SkillsCap { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int BaseSoundID { get; set; }

        DateTime NextCombatTime { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int NameHue { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int Hunger { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int Thirst { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int BAC { get; set; }

        /// <summary>
        /// Gets or sets the number of steps this player may take when hidden before being revealed.
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int AllowedStealthSteps { get; set; }

        Item Holding { get; set; }
        DateTime LastMoveTime { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Paralyzed { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool DisarmReady { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool StunReady { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Frozen { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="StatLockType">lock state</see> for the <see cref="RawStr" /> property.
        /// </summary>
        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        StatLockType StrLock { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="StatLockType">lock state</see> for the <see cref="RawDex" /> property.
        /// </summary>
        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        StatLockType DexLock { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="StatLockType">lock state</see> for the <see cref="RawInt" /> property.
        /// </summary>
        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        StatLockType IntLock { get; set; }

        DateTime NextActionTime { get; set; }
        DateTime NextActionMessage { get; set; }
        bool RegenThroughPoison { get; }
        bool CanRegenHits { get; }
        bool CanRegenStam { get; }
        bool CanRegenMana { get; }
        DateTime NextSkillTime { get; set; }
        List<AggressorInfo> Aggressors { get; }
        List<AggressorInfo> Aggressed { get; }
        bool ChangingCombatant { get; }

        /// <summary>
        /// Overridable. Gets or sets which Mobile that this Mobile is currently engaged in combat with.
        /// <seealso cref="OnCombatantChange" />
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        Mobile Combatant { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int TotalGold { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        int TotalItems { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        int TotalWeight { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        int TithingPoints { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int Followers { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int FollowersMax { get; set; }

        bool TargetLocked { get; set; }
        Target Target { get; set; }
        ContextMenu ContextMenu { get; set; }
        Prompt Prompt { get; set; }
        bool Pushing { get; set; }
        bool IsDeadBondedPet { get; }
        ISpell Spell { get; set; }

        [CommandProperty(AccessLevel.Administrator)]
        bool AutoPageNotify { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.Owner)]
        IAccount Account { get; set; }

        bool Deleted { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        int VirtualArmor { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        double ArmorRating { get; }

        /// <summary>
        /// Overridable. Returns true if the player is alive, false if otherwise. By default, this is computed by: <c>!Deleted &amp;&amp; (!Player || !Body.IsGhost)</c>
        /// </summary>
        [CommandProperty(AccessLevel.Counselor)]
        bool Alive { get; }

        bool RetainPackLocsOnDeath { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        Container Corpse { get; set; }

        List<DamageEntry> DamageEntries { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        Mobile LastKiller { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Squelched { get; set; }

        bool ShouldCheckStatTimers { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        DateTime CreationTime { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int LightLevel { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        string Profile { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        bool ProfileLocked { get; set; }

        [CommandProperty(AccessLevel.GameMaster, AccessLevel.Administrator)]
        bool Player { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        string Title { get; set; }

        List<Item> Items { get; }
        int MaxWeight { get; }

        [CommandProperty(AccessLevel.Counselor)]
        Skills Skills { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.Administrator)]
        AccessLevel AccessLevel { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int Fame { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int Karma { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Blessed { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        Map Map { get; set; }

        /// <summary>
        /// Gets a list of all <see cref="StatMod">StatMod's</see> currently active for the Mobile.
        /// </summary>
        List<StatMod> StatMods { get; }

        /// <summary>
        /// Gets or sets the base, unmodified, strength of the Mobile. Ranges from 1 to 65000, inclusive.
        /// <seealso cref="Str" />
        /// <seealso cref="StatMod" />
        /// <seealso cref="OnRawStrChange" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int RawStr { get; set; }

        /// <summary>
        /// Gets or sets the effective strength of the Mobile. This is the sum of the <see cref="RawStr" /> plus any additional modifiers. Any attempts to set this value when under the influence of a <see cref="StatMod" /> will result in no change. It ranges from 1 to 65000, inclusive.
        /// <seealso cref="RawStr" />
        /// <seealso cref="StatMod" />
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int Str { get; set; }

        /// <summary>
        /// Gets or sets the base, unmodified, dexterity of the Mobile. Ranges from 1 to 65000, inclusive.
        /// <seealso cref="Dex" />
        /// <seealso cref="StatMod" />
        /// <seealso cref="OnRawDexChange" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int RawDex { get; set; }

        /// <summary>
        /// Gets or sets the effective dexterity of the Mobile. This is the sum of the <see cref="RawDex" /> plus any additional modifiers. Any attempts to set this value when under the influence of a <see cref="StatMod" /> will result in no change. It ranges from 1 to 65000, inclusive.
        /// <seealso cref="RawDex" />
        /// <seealso cref="StatMod" />
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int Dex { get; set; }

        /// <summary>
        /// Gets or sets the base, unmodified, intelligence of the Mobile. Ranges from 1 to 65000, inclusive.
        /// <seealso cref="Int" />
        /// <seealso cref="StatMod" />
        /// <seealso cref="OnRawIntChange" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int RawInt { get; set; }

        /// <summary>
        /// Gets or sets the effective intelligence of the Mobile. This is the sum of the <see cref="RawInt" /> plus any additional modifiers. Any attempts to set this value when under the influence of a <see cref="StatMod" /> will result in no change. It ranges from 1 to 65000, inclusive.
        /// <seealso cref="RawInt" />
        /// <seealso cref="StatMod" />
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int Int { get; set; }

        /// <summary>
        /// Gets or sets the current hit point of the Mobile. This value ranges from 0 to <see cref="HitsMax" />, inclusive. When set to the value of <see cref="HitsMax" />, the <see cref="AggressorInfo.CanReportMurder">CanReportMurder</see> flag of all aggressors is reset to false, and the list of damage entries is cleared.
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int Hits { get; set; }

        /// <summary>
        /// Overridable. Gets the maximum hit point of the Mobile. By default, this returns: <c>50 + (<see cref="Str" /> / 2)</c>
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int HitsMax { get; }

        /// <summary>
        /// Gets or sets the current stamina of the Mobile. This value ranges from 0 to <see cref="StamMax" />, inclusive.
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int Stam { get; set; }

        /// <summary>
        /// Overridable. Gets the maximum stamina of the Mobile. By default, this returns: <c><see cref="Dex" /></c>
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int StamMax { get; }

        /// <summary>
        /// Gets or sets the current stamina of the Mobile. This value ranges from 0 to <see cref="ManaMax" />, inclusive.
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int Mana { get; set; }

        /// <summary>
        /// Overridable. Gets the maximum mana of the Mobile. By default, this returns: <c><see cref="Int" /></c>
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int ManaMax { get; }

        int Luck { get; }
        int HuedItemID { get; }

        [Hue, CommandProperty(AccessLevel.GameMaster)]
        int HueMod { get; set; }

        [Hue, CommandProperty(AccessLevel.GameMaster)]
        int Hue { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        Direction Direction { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Female { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Flying { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Warmode { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Hidden { get; set; }

        NetState NetState { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        string Language { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int SpeechHue { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int EmoteHue { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int WhisperHue { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int YellHue { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        string GuildTitle { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool DisplayGuildTitle { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        Mobile GuildFealty { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        string NameMod { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool YellowHealthbar { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        string RawName { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        string Name { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        DateTime LastStrGain { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        DateTime LastIntGain { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        DateTime LastDexGain { get; set; }

        DateTime LastStatGain { get; set; }
        BaseGuild Guild { get; set; }
        Timer PoisonTimer { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        Poison Poison { get; set; }

        ISpawner Spawner { get; set; }
        Region WalkRegion { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Poisoned { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool IsBodyMod { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        Body BodyMod { get; set; }

        [Body, CommandProperty(AccessLevel.GameMaster)]
        Body Body { get; set; }

        [Body, CommandProperty(AccessLevel.GameMaster)]
        int BodyValue { get; set; }

        [CommandProperty(AccessLevel.Counselor)]
        Serial Serial { get; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        Point3D Location { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        Point3D LogoutLocation { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        Map LogoutMap { get; set; }

        Region Region { get; }
        Packet RemovePacket { get; }
        Packet OPLPacket { get; }
        ObjectPropertyList PropertyList { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        int SolidHueOverride { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int HairItemID { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int FacialHairItemID { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int HairHue { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int FacialHairHue { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        IWeapon Weapon { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        BankBox BankBox { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        Container Backpack { get; }

        bool KeepsItemsOnDeath { get; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        int X { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        int Y { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        int Z { get; set; }

        bool HasTrade { get; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        int Kills { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int ShortTermMurders { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        bool Criminal { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        IMount Mount { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Mounted { get; }

        QuestArrow QuestArrow { get; set; }
        bool CanTarget { get; }
        bool ClickTitle { get; }
        bool PropertyTitle { get; }
        bool ShowFameTitle { get; }
        Item ShieldArmor { get; }
        Item NeckArmor { get; }
        Item HandArmor { get; }
        Item HeadArmor { get; }
        Item ArmsArmor { get; }
        Item LegsArmor { get; }
        Item ChestArmor { get; }
        Item Talisman { get; }

        /// <summary>
        /// Gets or sets the maximum attainable value for <see cref="RawStr" />, <see cref="RawDex" />, and <see cref="RawInt" />.
        /// </summary>
        [CommandProperty(AccessLevel.GameMaster)]
        int StatCap { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool Meditating { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool CanSwim { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool CantWalk { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        bool CanHearGhosts { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        int RawStatTotal { get; }

        DateTime NextSpellTime { get; set; }

        void ComputeLightLevels( out int global, out int personal );
        void ComputeBaseLightLevels( out int global, out int personal );
        void CheckLightLevels( bool forceResend );
        void UpdateResistances();
        int GetResistance( ResistanceType type );
        void AddResistanceMod( ResistanceMod toAdd );
        void RemoveResistanceMod( ResistanceMod toRemove );
        void ComputeResistances();
        int GetMinResistance( ResistanceType type );
        int GetMaxResistance( ResistanceType type );
        void SendPropertiesTo( Mobile from );
        void OnAosSingleClick( Mobile from );
        string ApplyNameSuffix( string suffix );
        void AddNameProperties( ObjectPropertyList list );
        void GetProperties( ObjectPropertyList list );
        void GetChildProperties( ObjectPropertyList list, Item item );
        void GetChildNameProperties( ObjectPropertyList list, Item item );

        /// <summary>
        /// Overridable. Virtual event invoked when <paramref name="skill" /> changes in some way.
        /// </summary>
        void OnSkillInvalidated( Skill skill );

        void UpdateSkillMods();
        void ValidateSkillMods();
        void AddSkillMod( SkillMod mod );
        void RemoveSkillMod( SkillMod mod );

        /// <summary>
        /// Overridable. Virtual event invoked when a client, <paramref name="from" />, invokes a 'help request' for the Mobile. Seemingly no longer functional in newer clients.
        /// </summary>
        void OnHelpRequest( Mobile from );

        void DelayChangeWarmode( bool value );
        bool InLOS( Mobile target );
        bool InLOS( object target );
        bool InLOS( Point3D target );
        bool BeginAction( object toLock );
        bool CanBeginAction( object toLock );
        void EndAction( object toLock );
        TimeSpan GetLogoutDelay();
        void Paralyze( TimeSpan duration );
        void Freeze( TimeSpan duration );
        string ToString();
        void SendSkillMessage();
        void SendActionMessage();
        void ClearHands();
        void ClearHand( Item item );
        void Attack( Mobile m );
        bool CheckAttack( Mobile m );

        /// <summary>
        /// Overridable. Virtual event invoked after the <see cref="Combatant" /> property has changed.
        /// <seealso cref="Combatant" />
        /// </summary>
        void OnCombatantChange();

        double GetDistanceToSqrt( Point3D p );
        double GetDistanceToSqrt( Mobile m );
        double GetDistanceToSqrt( IPoint2D p );
        void AggressiveAction( Mobile aggressor );
        void AggressiveAction( Mobile aggressor, bool criminal );
        void RemoveAggressed( Mobile aggressed );
        void RemoveAggressor( Mobile aggressor );
        int GetTotal( TotalType type );
        void UpdateTotal( Item sender, TotalType type, int delta );
        void UpdateTotals();
        void ClearQuestArrow();
        void ClearTarget();
        Target BeginTarget( int range, bool allowGround, TargetFlags flags, TargetCallback callback );
        Target BeginTarget( int range, bool allowGround, TargetFlags flags, TargetStateCallback callback, object state );
        bool CheckContextMenuDisplay( IEntity target );
        Prompt BeginPrompt( PromptCallback callback, PromptCallback cancelCallback );
        Prompt BeginPrompt( PromptCallback callback, bool callbackHandlesCancel );
        Prompt BeginPrompt( PromptCallback callback );
        Prompt BeginPrompt( PromptStateCallback callback, PromptStateCallback cancelCallback, object state );
        Prompt BeginPrompt( PromptStateCallback callback, bool callbackHandlesCancel, object state );
        Prompt BeginPrompt( PromptStateCallback callback, object state );
        void ClearFastwalkStack();
        bool CheckMovement( Direction d, out int newZ );
        bool Move( Direction d );
        void OnAfterMove( Point3D oldLocation );
        TimeSpan ComputeMovementSpeed();
        TimeSpan ComputeMovementSpeed( Direction dir );
        TimeSpan ComputeMovementSpeed( Direction dir, bool checkTurning );

        /// <summary>
        /// Overridable. Virtual event invoked when a Mobile <paramref name="m" /> moves off this Mobile.
        /// </summary>
        /// <returns>True if the move is allowed, false if not.</returns>
        bool OnMoveOff( Mobile m );

        /// <summary>
        /// Overridable. Event invoked when a Mobile <paramref name="m" /> moves over this Mobile.
        /// </summary>
        /// <returns>True if the move is allowed, false if not.</returns>
        bool OnMoveOver( Mobile m );

        bool CheckShove( Mobile shoved );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile sees another Mobile, <paramref name="m" />, move.
        /// </summary>
        void OnMovement( Mobile m, Point3D oldLocation );

        void CriminalAction( bool message );
        bool CanUseStuckMenu();
        bool IsSnoop( Mobile from );

        /// <summary>
        /// Overridable. Any call to <see cref="Resurrect" /> will silently fail if this method returns false.
        /// <seealso cref="Resurrect" />
        /// </summary>
        bool CheckResurrect();

        /// <summary>
        /// Overridable. Event invoked before the Mobile is <see cref="Resurrect">resurrected</see>.
        /// <seealso cref="Resurrect" />
        /// </summary>
        void OnBeforeResurrect();

        /// <summary>
        /// Overridable. Event invoked after the Mobile is <see cref="Resurrect">resurrected</see>.
        /// <seealso cref="Resurrect" />
        /// </summary>
        void OnAfterResurrect();

        void Resurrect();
        void DropHolding();
        void Delete();

        /// <summary>
        /// Overridable. Virtual event invoked before the Mobile is deleted.
        /// </summary>
        void OnDelete();

        bool CheckSpellCast( ISpell spell );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile casts a <paramref name="spell" />.
        /// </summary>
        /// <param name="spell"></param>
        void OnSpellCast( ISpell spell );

        /// <summary>
        /// Overridable. Virtual event invoked after <see cref="TotalWeight" /> changes.
        /// </summary>
        void OnWeightChange( int oldValue );

        /// <summary>
        /// Overridable. Virtual event invoked when the <see cref="Skill.Base" /> or <see cref="Skill.BaseFixedPoint" /> property of <paramref name="skill" /> changes.
        /// </summary>
        void OnSkillChange( SkillName skill, double oldBase );

        /// <summary>
        /// Overridable. Invoked after the mobile is deleted. When overriden, be sure to call the base method.
        /// </summary>
        void OnAfterDelete();

        bool AllowSkillUse( SkillName name );
        bool UseSkill( SkillName name );
        bool UseSkill( int skillID );
        DeathMoveResult GetParentMoveResultFor( Item item );
        DeathMoveResult GetInventoryMoveResultFor( Item item );
        void Kill();

        /// <summary>
        /// Overridable. Event invoked before the Mobile is <see cref="Kill">killed</see>.
        /// <seealso cref="Kill" />
        /// <seealso cref="OnDeath" />
        /// </summary>
        /// <returns>True to continue with death, false to override it.</returns>
        bool OnBeforeDeath();

        /// <summary>
        /// Overridable. Event invoked after the Mobile is <see cref="Kill">killed</see>. Primarily, this method is responsible for deleting an NPC or turning a PC into a ghost.
        /// <seealso cref="Kill" />
        /// <seealso cref="OnBeforeDeath" />
        /// </summary>
        void OnDeath( Container c );

        int GetAngerSound();
        int GetIdleSound();
        int GetAttackSound();
        int GetHurtSound();
        int GetDeathSound();
        bool CheckTarget( Mobile from, Target targ, object targeted );
        void Use( Item item );
        void Use( Mobile m );
        void Lift( Item item, int amount, out bool rejected, out LRReason reject );
        void SendDropEffect( Item item );
        bool Drop( Item to, Point3D loc );
        bool Drop( Point3D loc );
        bool Drop( Mobile to, Point3D loc );
        bool MutateSpeech( List<Mobile> hears, ref string text, ref object context );
        void Manifest( TimeSpan delay );
        bool CheckSpeechManifest();
        bool CheckHearsMutatedSpeech( Mobile m, object context );
        IPooledEnumerable GetItemsInRange( int range );
        IPooledEnumerable GetObjectsInRange( int range );
        IPooledEnumerable GetMobilesInRange( int range );
        IPooledEnumerable GetClientsInRange( int range );
        void DoSpeech( string text, int[] keywords, MessageType type, int hue );
        Mobile FindMostRecentDamager( bool allowSelf );
        DamageEntry FindMostRecentDamageEntry( bool allowSelf );
        Mobile FindLeastRecentDamager( bool allowSelf );
        DamageEntry FindLeastRecentDamageEntry( bool allowSelf );
        Mobile FindMostTotalDamger( bool allowSelf );
        DamageEntry FindMostTotalDamageEntry( bool allowSelf );
        Mobile FindLeastTotalDamger( bool allowSelf );
        DamageEntry FindLeastTotalDamageEntry( bool allowSelf );
        DamageEntry FindDamageEntryFor( Mobile m );
        Mobile GetDamageMaster( Mobile damagee );
        DamageEntry RegisterDamage( int amount, Mobile from );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile is <see cref="Damage">damaged</see>. It is called before <see cref="Hits">hit points</see> are lowered or the Mobile is <see cref="Kill">killed</see>.
        /// <seealso cref="Damage" />
        /// <seealso cref="Hits" />
        /// <seealso cref="Kill" />
        /// </summary>
        void OnDamage( int amount, Mobile from, bool willKill );

        void Damage( int amount );
        bool CanBeDamaged();
        void Damage( int amount, Mobile from );
        void Damage( int amount, Mobile from, bool informMount );
        void SendDamageToAll( int amount );
        void Heal( int amount );
        void Heal( int amount, Mobile from );
        void Heal( int amount, Mobile from, bool message );
        void OnHeal( ref int amount, Mobile from );
        void UsedStuckMenu();
        void Deserialize( GenericReader reader );
        void ConvertHair();
        void CheckStatTimers();
        void Serialize( GenericWriter writer );
        bool CanPaperdollBeOpenedBy( Mobile from );
        void GetChildContextMenuEntries( Mobile from, List<ContextMenuEntry> list, Item item );
        void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list );
        void Internalize();

        /// <summary>
        /// Overridable. Virtual event invoked when <paramref name="item" /> is <see cref="AddItem">added</see> from the Mobile, such as when it is equiped.
        /// <seealso cref="Items" />
        /// <seealso cref="OnItemRemoved" />
        /// </summary>
        void OnItemAdded( Item item );

        /// <summary>
        /// Overridable. Virtual event invoked when <paramref name="item" /> is <see cref="RemoveItem">removed</see> from the Mobile.
        /// <seealso cref="Items" />
        /// <seealso cref="OnItemAdded" />
        /// </summary>
        void OnItemRemoved( Item item );

        /// <summary>
        /// Overridable. Virtual event invoked when <paramref name="item" /> is becomes a child of the Mobile; it's worn or contained at some level of the Mobile's <see cref="Mobile.Backpack">backpack</see> or <see cref="Mobile.BankBox">bank box</see>
        /// <seealso cref="OnSubItemRemoved" />
        /// <seealso cref="OnItemAdded" />
        /// </summary>
        void OnSubItemAdded( Item item );

        /// <summary>
        /// Overridable. Virtual event invoked when <paramref name="item" /> is removed from the Mobile, its <see cref="Mobile.Backpack">backpack</see>, or its <see cref="Mobile.BankBox">bank box</see>.
        /// <seealso cref="OnSubItemAdded" />
        /// <seealso cref="OnItemRemoved" />
        /// </summary>
        void OnSubItemRemoved( Item item );

        void OnItemBounceCleared( Item item );
        void OnSubItemBounceCleared( Item item );
        void AddItem( Item item );
        void RemoveItem( Item item );
        void Animate( int action, int frameCount, int repeatCount, bool forward, bool repeat, int delay );
        void SendSound( int soundID );
        void SendSound( int soundID, IPoint3D p );
        void PlaySound( int soundID );
        void OnAccessLevelChanged( AccessLevel oldLevel );
        void OnFameChange( int oldValue );
        void OnKarmaChange( int oldValue );
        void RevealingAction();
        void SayTo( Mobile to, bool ascii, string text );
        void SayTo( Mobile to, string text );
        void SayTo( Mobile to, string format, params object[] args );
        void SayTo( Mobile to, bool ascii, string format, params object[] args );
        void SayTo( Mobile to, int number );
        void SayTo( Mobile to, int number, string args );
        void Say( bool ascii, string text );
        void Say( string text );
        void Say( string format, params object[] args );
        void Say( int number, AffixType type, string affix, string args );
        void Say( int number );
        void Say( int number, string args );
        void Emote( string text );
        void Emote( string format, params object[] args );
        void Emote( int number );
        void Emote( int number, string args );
        void Whisper( string text );
        void Whisper( string format, params object[] args );
        void Whisper( int number );
        void Whisper( int number, string args );
        void Yell( string text );
        void Yell( string format, params object[] args );
        void Yell( int number );
        void Yell( int number, string args );
        void SendRemovePacket();
        void SendRemovePacket( bool everyone );
        void ClearScreen();
        bool Send( Packet p );
        bool Send( Packet p, bool throwOnOffline );
        bool SendHuePicker( HuePicker p );
        bool SendHuePicker( HuePicker p, bool throwOnOffline );
        Gump FindGump( Type type );
        bool CloseGump( Type type );

        [Obsolete( "Use CloseGump( Type ) instead." )]
        bool CloseGump( Type type, int buttonID );

        [Obsolete( "Use CloseGump( Type ) instead." )]
        bool CloseGump( Type type, int buttonID, bool throwOnOffline );

        bool CloseAllGumps();

        [Obsolete( "Use CloseAllGumps() instead.", false )]
        bool CloseAllGumps( bool throwOnOffline );

        bool HasGump( Type type );

        [Obsolete( "Use HasGump( Type ) instead.", false )]
        bool HasGump( Type type, bool throwOnOffline );

        bool SendGump( Gump g );
        bool SendGump( Gump g, bool throwOnOffline );
        bool SendMenu( IMenu m );
        bool SendMenu( IMenu m, bool throwOnOffline );

        /// <summary>
        /// Overridable. Event invoked before the Mobile says something.
        /// <seealso cref="DoSpeech" />
        /// </summary>
        void OnSaid( SpeechEventArgs e );

        bool HandlesOnSpeech( Mobile from );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile hears speech. This event will only be invoked if <see cref="HandlesOnSpeech" /> returns true.
        /// <seealso cref="DoSpeech" />
        /// </summary>
        void OnSpeech( SpeechEventArgs e );

        void SendEverything();
        void UpdateRegion();
        bool CanBeBeneficial( Mobile target );
        bool CanBeBeneficial( Mobile target, bool message );
        bool CanBeBeneficial( Mobile target, bool message, bool allowDead );
        bool IsBeneficialCriminal( Mobile target );

        /// <summary>
        /// Overridable. Event invoked when the Mobile <see cref="DoBeneficial">does a beneficial action</see>.
        /// </summary>
        void OnBeneficialAction( Mobile target, bool isCriminal );

        void DoBeneficial( Mobile target );
        bool BeneficialCheck( Mobile target );
        bool CanBeHarmful( Mobile target );
        bool CanBeHarmful( Mobile target, bool message );
        bool CanBeHarmful( Mobile target, bool message, bool ignoreOurBlessedness );
        bool IsHarmfulCriminal( Mobile target );

        /// <summary>
        /// Overridable. Event invoked when the Mobile <see cref="DoHarmful">does a harmful action</see>.
        /// </summary>
        void OnHarmfulAction( Mobile target, bool isCriminal );

        void DoHarmful( Mobile target );
        void DoHarmful( Mobile target, bool indirect );
        bool HarmfulCheck( Mobile target );
        bool RemoveStatMod( string name );
        StatMod GetStatMod( string name );
        void AddStatMod( StatMod mod );

        /// <summary>
        /// Computes the total modified offset for the specified stat type. Expired <see cref="StatMod" /> instances are removed.
        /// </summary>
        int GetStatOffset( StatType type );

        /// <summary>
        /// Overridable. Virtual event invoked when the <see cref="RawStr" /> changes.
        /// <seealso cref="RawStr" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        void OnRawStrChange( int oldValue );

        /// <summary>
        /// Overridable. Virtual event invoked when <see cref="RawDex" /> changes.
        /// <seealso cref="RawDex" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        void OnRawDexChange( int oldValue );

        /// <summary>
        /// Overridable. Virtual event invoked when the <see cref="RawInt" /> changes.
        /// <seealso cref="RawInt" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        void OnRawIntChange( int oldValue );

        /// <summary>
        /// Overridable. Virtual event invoked when the <see cref="RawStr" />, <see cref="RawDex" />, or <see cref="RawInt" /> changes.
        /// <seealso cref="OnRawStrChange" />
        /// <seealso cref="OnRawDexChange" />
        /// <seealso cref="OnRawIntChange" />
        /// </summary>
        void OnRawStatChange( StatType stat, int oldValue );

        void OnHitsChange( int oldValue );
        void OnStamChange( int oldValue );
        void OnManaChange( int oldValue );
        void SetDirection( Direction dir );
        int GetSeason();
        int GetPacketFlags();
        int GetOldPacketFlags();
        void OnGenderChanged( bool oldFemale );

        /// <summary>
        /// Overridable. Virtual event invoked after the Warmode property has changed.
        /// </summary>
        void OnWarmodeChanged();

        void OnConnected();
        void OnDisconnected();
        void OnNetStateChanged();
        bool CanSee( object o );
        bool CanSee( Item item );
        bool CanSee( Mobile m );
        bool CanBeRenamedBy( Mobile from );
        void OnGuildTitleChange( string oldTitle );
        void OnGuildChange( BaseGuild oldGuild );

        /// <summary>
        /// Overridable. Event invoked when a call to <see cref="ApplyPoison" /> failed because <see cref="CheckPoisonImmunity" /> returned false: the Mobile was resistant to the poison. By default, this broadcasts an overhead message: * The poison seems to have no effect. *
        /// <seealso cref="CheckPoisonImmunity" />
        /// <seealso cref="ApplyPoison" />
        /// <seealso cref="Poison" />
        /// </summary>
        void OnPoisonImmunity( Mobile from, Poison poison );

        /// <summary>
        /// Overridable. Virtual event invoked when a call to <see cref="ApplyPoison" /> failed because <see cref="CheckHigherPoison" /> returned false: the Mobile was already poisoned by an equal or greater strength poison.
        /// <seealso cref="CheckHigherPoison" />
        /// <seealso cref="ApplyPoison" />
        /// <seealso cref="Poison" />
        /// </summary>
        void OnHigherPoison( Mobile from, Poison poison );

        /// <summary>
        /// Overridable. Event invoked when a call to <see cref="ApplyPoison" /> succeeded. By default, this broadcasts an overhead message varying by the level of the poison. Example: * Zippy begins to spasm uncontrollably. *
        /// <seealso cref="ApplyPoison" />
        /// <seealso cref="Poison" />
        /// </summary>
        void OnPoisoned( Mobile from, Poison poison, Poison oldPoison );

        /// <summary>
        /// Overridable. Called from <see cref="ApplyPoison" />, this method checks if the Mobile is immune to some <see cref="Poison" />. If true, <see cref="OnPoisonImmunity" /> will be invoked and <see cref="ApplyPoisonResult.Immune" /> is returned.
        /// <seealso cref="OnPoisonImmunity" />
        /// <seealso cref="ApplyPoison" />
        /// <seealso cref="Poison" />
        /// </summary>
        bool CheckPoisonImmunity( Mobile from, Poison poison );

        /// <summary>
        /// Overridable. Called from <see cref="ApplyPoison" />, this method checks if the Mobile is already poisoned by some <see cref="Poison" /> of equal or greater strength. If true, <see cref="OnHigherPoison" /> will be invoked and <see cref="ApplyPoisonResult.HigherPoisonActive" /> is returned.
        /// <seealso cref="OnHigherPoison" />
        /// <seealso cref="ApplyPoison" />
        /// <seealso cref="Poison" />
        /// </summary>
        bool CheckHigherPoison( Mobile from, Poison poison );

        /// <summary>
        /// Overridable. Attempts to apply poison to the Mobile. Checks are made such that no <see cref="CheckHigherPoison">higher poison is active</see> and that the Mobile is not <see cref="CheckPoisonImmunity">immune to the poison</see>. Provided those assertions are true, the <paramref name="poison" /> is applied and <see cref="OnPoisoned" /> is invoked.
        /// <seealso cref="Poison" />
        /// <seealso cref="CurePoison" />
        /// </summary>
        /// <returns>One of four possible values:
        /// <list type="table">
        /// <item>
        /// <term><see cref="ApplyPoisonResult.Cured">Cured</see></term>
        /// <description>The <paramref name="poison" /> parameter was null and so <see cref="CurePoison" /> was invoked.</description>
        /// </item>
        /// <item>
        /// <term><see cref="ApplyPoisonResult.HigherPoisonActive">HigherPoisonActive</see></term>
        /// <description>The call to <see cref="CheckHigherPoison" /> returned false.</description>
        /// </item>
        /// <item>
        /// <term><see cref="ApplyPoisonResult.Immune">Immune</see></term>
        /// <description>The call to <see cref="CheckPoisonImmunity" /> returned false.</description>
        /// </item>
        /// <item>
        /// <term><see cref="ApplyPoisonResult.Poisoned">Poisoned</see></term>
        /// <description>The <paramref name="poison" /> was successfully applied.</description>
        /// </item>
        /// </list>
        /// </returns>
        ApplyPoisonResult ApplyPoison( Mobile from, Poison poison );

        /// <summary>
        /// Overridable. Called from <see cref="CurePoison" />, this method checks to see that the Mobile can be cured of <see cref="Poison" />
        /// <seealso cref="CurePoison" />
        /// <seealso cref="Poison" />
        /// </summary>
        bool CheckCure( Mobile from );

        /// <summary>
        /// Overridable. Virtual event invoked when a call to <see cref="CurePoison" /> succeeded.
        /// <seealso cref="CurePoison" />
        /// <seealso cref="CheckCure" />
        /// <seealso cref="Poison" />
        /// </summary>
        void OnCured( Mobile from, Poison oldPoison );

        /// <summary>
        /// Overridable. Virtual event invoked when a call to <see cref="CurePoison" /> failed.
        /// <seealso cref="CurePoison" />
        /// <seealso cref="CheckCure" />
        /// <seealso cref="Poison" />
        /// </summary>
        void OnFailedCure( Mobile from );

        /// <summary>
        /// Overridable. Attempts to cure any poison that is currently active.
        /// </summary>
        /// <returns>True if poison was cured, false if otherwise.</returns>
        bool CurePoison( Mobile from );

        void OnBeforeSpawn( Point3D location, Map m );
        void OnAfterSpawn();
        int SafeBody( int body );
        void FreeCache();
        void ClearProperties();
        void InvalidateProperties();
        void MoveToWorld( Point3D newLocation, Map map );
        void SetLocation( Point3D newLocation, bool isTeleport );
        bool HasFreeHand();
        IWeapon GetDefaultWeapon();
        BankBox FindBankNoCreate();
        Item FindItemOnLayer( Layer layer );
        void MovingEffect( IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode );
        void MovingEffect( IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes );
        void MovingParticles( IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, EffectLayer layer, int unknown );
        void MovingParticles( IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, int unknown );
        void MovingParticles( IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int effect, int explodeEffect, int explodeSound, int unknown );
        void MovingParticles( IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int effect, int explodeEffect, int explodeSound );
        void FixedEffect( int itemID, int speed, int duration, int hue, int renderMode );
        void FixedEffect( int itemID, int speed, int duration );
        void FixedParticles( int itemID, int speed, int duration, int effect, int hue, int renderMode, EffectLayer layer, int unknown );
        void FixedParticles( int itemID, int speed, int duration, int effect, int hue, int renderMode, EffectLayer layer );
        void FixedParticles( int itemID, int speed, int duration, int effect, EffectLayer layer, int unknown );
        void FixedParticles( int itemID, int speed, int duration, int effect, EffectLayer layer );
        void BoltEffect( int hue );
        void SendIncomingPacket();
        bool PlaceInBackpack( Item item );
        bool AddToBackpack( Item item );
        bool CheckLift( Mobile from, Item item, ref LRReason reject );
        bool CheckNonlocalLift( Mobile from, Item item );
        bool CheckTrade( Mobile to, Item item, SecureTradeContainer cont, bool message, bool checkItems, int plusItems, int plusWeight );

        /// <summary>
        /// Overridable. Event invoked when a Mobile (<paramref name="from" />) drops an <see cref="Item"><paramref name="dropped" /></see> onto the Mobile.
        /// </summary>
        bool OnDragDrop( Mobile from, Item dropped );

        bool CheckEquip( Item item );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile attempts to wear <paramref name="item" />.
        /// </summary>
        /// <returns>True if the request is accepted, false if otherwise.</returns>
        bool OnEquip( Item item );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile attempts to lift <paramref name="item" />.
        /// </summary>
        /// <returns>True if the lift is allowed, false if otherwise.</returns>
        /// <example>
        /// The following example demonstrates usage. It will disallow any attempts to pick up a pick axe if the Mobile does not have enough strength.
        /// <code>
        /// public override bool OnDragLift( Item item )
        /// {
        ///		if ( item is Pickaxe &amp;&amp; this.Str &lt; 60 )
        ///		{
        ///			SendMessage( "That is too heavy for you to lift." );
        ///			return false;
        ///		}
        ///		
        ///		return base.OnDragLift( item );
        /// }</code>
        /// </example>
        bool OnDragLift( Item item );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile attempts to drop <paramref name="item" /> into a <see cref="Container"><paramref name="container" /></see>.
        /// </summary>
        /// <returns>True if the drop is allowed, false if otherwise.</returns>
        bool OnDroppedItemInto( Item item, Container container, Point3D loc );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile attempts to drop <paramref name="item" /> directly onto another <see cref="Item" />, <paramref name="target" />. This is the case of stacking items.
        /// </summary>
        /// <returns>True if the drop is allowed, false if otherwise.</returns>
        bool OnDroppedItemOnto( Item item, Item target );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile attempts to drop <paramref name="item" /> into another <see cref="Item" />, <paramref name="target" />. The target item is most likely a <see cref="Container" />.
        /// </summary>
        /// <returns>True if the drop is allowed, false if otherwise.</returns>
        bool OnDroppedItemToItem( Item item, Item target, Point3D loc );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile attempts to give <paramref name="item" /> to a Mobile (<paramref name="target" />).
        /// </summary>
        /// <returns>True if the drop is allowed, false if otherwise.</returns>
        bool OnDroppedItemToMobile( Item item, Mobile target );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile attempts to drop <paramref name="item" /> to the world at a <see cref="Point3D"><paramref name="location" /></see>.
        /// </summary>
        /// <returns>True if the drop is allowed, false if otherwise.</returns>
        bool OnDroppedItemToWorld( Item item, Point3D location );

        /// <summary>
        /// Overridable. Virtual event when <paramref name="from" /> successfully uses <paramref name="item" /> while it's on this Mobile.
        /// <seealso cref="Item.OnItemUsed" />
        /// </summary>
        void OnItemUsed( Mobile from, Item item );

        bool CheckNonlocalDrop( Mobile from, Item item, Item target );
        bool CheckItemUse( Mobile from, Item item );

        /// <summary>
        /// Overridable. Virtual event invoked when <paramref name="from" /> successfully lifts <paramref name="item" /> from this Mobile.
        /// <seealso cref="Item.OnItemLifted" />
        /// </summary>
        void OnItemLifted( Mobile from, Item item );

        bool AllowItemUse( Item item );
        bool AllowEquipFrom( Mobile mob );
        bool EquipItem( Item item );
        void DefaultMobileInit();
        void Delta( MobileDelta flag );
        Direction GetDirectionTo( int x, int y );
        Direction GetDirectionTo( Point2D p );
        Direction GetDirectionTo( Point3D p );
        Direction GetDirectionTo( IPoint2D p );
        void ProcessDelta();
        void OnKillsChange( int oldValue );
        bool CheckAlive();
        bool CheckAlive( bool message );
        void PublicOverheadMessage( MessageType type, int hue, bool ascii, string text );
        void PublicOverheadMessage( MessageType type, int hue, bool ascii, string text, bool noLineOfSight );
        void PublicOverheadMessage( MessageType type, int hue, int number );
        void PublicOverheadMessage( MessageType type, int hue, int number, string args );
        void PublicOverheadMessage( MessageType type, int hue, int number, string args, bool noLineOfSight );
        void PublicOverheadMessage( MessageType type, int hue, int number, AffixType affixType, string affix, string args );
        void PublicOverheadMessage( MessageType type, int hue, int number, AffixType affixType, string affix, string args, bool noLineOfSight );
        void PrivateOverheadMessage( MessageType type, int hue, bool ascii, string text, NetState state );
        void PrivateOverheadMessage( MessageType type, int hue, int number, NetState state );
        void PrivateOverheadMessage( MessageType type, int hue, int number, string args, NetState state );
        void LocalOverheadMessage( MessageType type, int hue, bool ascii, string text );
        void LocalOverheadMessage( MessageType type, int hue, int number );
        void LocalOverheadMessage( MessageType type, int hue, int number, string args );
        void NonlocalOverheadMessage( MessageType type, int hue, int number );
        void NonlocalOverheadMessage( MessageType type, int hue, int number, string args );
        void NonlocalOverheadMessage( MessageType type, int hue, bool ascii, string text );
        void SendLocalizedMessage( int number );
        void SendLocalizedMessage( int number, string args );
        void SendLocalizedMessage( int number, string args, int hue );
        void SendLocalizedMessage( int number, bool append, string affix );
        void SendLocalizedMessage( int number, bool append, string affix, string args );
        void SendLocalizedMessage( int number, bool append, string affix, string args, int hue );
        void LaunchBrowser( string url );
        void SendMessage( string text );
        void SendMessage( string format, params object[] args );
        void SendMessage( int hue, string text );
        void SendMessage( int hue, string format, params object[] args );
        void SendAsciiMessage( string text );
        void SendAsciiMessage( string format, params object[] args );
        void SendAsciiMessage( int hue, string text );
        void SendAsciiMessage( int hue, string format, params object[] args );
        bool InRange( Point2D p, int range );
        bool InRange( Point3D p, int range );
        bool InRange( IPoint2D p, int range );
        void InitStats( int str, int dex, int intel );
        void DisplayPaperdollTo( Mobile to );

        /// <summary>
        /// Overridable. Event invoked when the Mobile is double clicked. By default, this method can either dismount or open the paperdoll.
        /// <seealso cref="CanPaperdollBeOpenedBy" />
        /// <seealso cref="DisplayPaperdollTo" />
        /// </summary>
        void OnDoubleClick( Mobile from );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile is double clicked by someone who is over 18 tiles away.
        /// <seealso cref="OnDoubleClick" />
        /// </summary>
        void OnDoubleClickOutOfRange( Mobile from );

        /// <summary>
        /// Overridable. Virtual event invoked when the Mobile is double clicked by someone who can no longer see the Mobile. This may happen, for example, using 'Last Object' after the Mobile has hidden.
        /// <seealso cref="OnDoubleClick" />
        /// </summary>
        void OnDoubleClickCantSee( Mobile from );

        /// <summary>
        /// Overridable. Event invoked when the Mobile is double clicked by someone who is not alive. Similar to <see cref="OnDoubleClick" />, this method will show the paperdoll. It does not, however, provide any dismount functionality.
        /// <seealso cref="OnDoubleClick" />
        /// </summary>
        void OnDoubleClickDead( Mobile from );

        /// <summary>
        /// Overridable. Event invoked when the Mobile requests to open his own paperdoll via the 'Open Paperdoll' macro.
        /// </summary>
        void OnPaperdollRequest();

        /// <summary>
        /// Overridable. Event invoked when <paramref name="from" /> wants to see this Mobile's stats.
        /// </summary>
        /// <param name="from"></param>
        void OnStatsQuery( Mobile from );

        /// <summary>
        /// Overridable. Event invoked when <paramref name="from" /> wants to see this Mobile's skills.
        /// </summary>
        void OnSkillsQuery( Mobile from );

        /// <summary>
        /// Overridable. Virtual event invoked when <see cref="Region" /> changes.
        /// </summary>
        void OnRegionChange( Region Old, Region New );

        /// <summary>
        /// Overridable. Event invoked when the Mobile is single clicked.
        /// </summary>
        void OnSingleClick( Mobile from );

        bool CheckSkill( SkillName skill, double minSkill, double maxSkill );
        bool CheckSkill( SkillName skill, double chance );
        bool CheckTargetSkill( SkillName skill, object target, double minSkill, double maxSkill );
        bool CheckTargetSkill( SkillName skill, object target, double chance );
        void DisruptiveAction();

        /// <summary>
        /// Overridable. Virtual event invoked when the sector this Mobile is in gets <see cref="Sector.Activate">activated</see>.
        /// </summary>
        void OnSectorActivate();

        /// <summary>
        /// Overridable. Virtual event invoked when the sector this Mobile is in gets <see cref="Sector.Deactivate">deactivated</see>.
        /// </summary>
        void OnSectorDeactivate();
    }
}