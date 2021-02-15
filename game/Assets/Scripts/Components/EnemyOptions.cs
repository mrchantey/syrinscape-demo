using System;
using Unity.Entities;
using UnityEngine;
using System.Linq;

namespace SyrinscapeDemo
{


	[Serializable]
	public struct EnemyOptions : ISharedComponentData, IEquatable<EnemyOptions>
	{
		public EnemyType[] enemyTypes;
		public Entity prefab;
		public float spawnFreq;

		public bool Equals(EnemyOptions other)
		{
			return GetHashCode() == other.GetHashCode();
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}