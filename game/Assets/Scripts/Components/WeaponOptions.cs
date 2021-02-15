using System;
using Unity.Entities;
using UnityEngine;
using System.Linq;

namespace SyrinscapeDemo
{


	[Serializable]
	public struct WeaponOptions : ISharedComponentData, IEquatable<WeaponOptions>
	{
		public WeaponType[] weaponTypes;
		public Entity prefab;

		public bool Equals(WeaponOptions other)
		{
			return GetHashCode() == other.GetHashCode();
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}