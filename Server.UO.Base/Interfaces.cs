/***************************************************************************
 *                               Interfaces.cs
 *                            -------------------
 *   begin                : May 1, 2002
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id: Interfaces.cs 4 2006-06-15 04:28:39Z mark $
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using System;
using System.Collections;

namespace Server.Mobiles
{
	public interface IMount
	{
		IMobile Rider{ get; set; }
		void OnRiderDamaged( int amount, IMobile from, bool willKill );
	}

	public interface IMountItem 
	{
		IMount Mount{ get; }
	}
}

namespace Server
{
	public interface IVendor
	{
		bool OnBuyItems( IMobile from, ArrayList list );
		bool OnSellItems( IMobile from, ArrayList list );

		DateTime LastRestock{ get; set; }
		TimeSpan RestockDelay{ get; }
		void Restock();
	}

	public interface ICarvable
	{
		void Carve( IMobile from, Item item );
	}

	public interface IWeapon
	{
		int MaxRange{ get; }
		void OnBeforeSwing( IMobile attacker, IMobile defender );
		TimeSpan OnSwing( IMobile attacker, IMobile defender );
		void GetStatusDamage( IMobile from, out int min, out int max );
	}

	public interface IHued
	{
		int HuedItemID{ get; }
	}

	public interface ISpell
	{
		bool IsCasting{ get; }
		void OnCasterHurt( int damage );
		void OnCasterKilled();
		void OnConnectionChanged();
		bool OnCasterMoving( Direction d );
		bool OnCasterEquiping( Item item );
		bool OnCasterUsingObject( object o );
		bool OnCastInTown( Region r );
	}

	public interface IParty
	{
		void OnStamChanged( IMobile m );
		void OnManaChanged( IMobile m );
		void OnStatsQuery( IMobile beholder, IMobile beheld );
	}
}