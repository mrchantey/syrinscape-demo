using System;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace SyrinscapeDemo
{


	[Serializable]
	public struct Score : ISharedComponentData, IEquatable<Score>
	{
		public int score;
		public int lastScore;
		public Text text;

		public bool Equals(Score other)
		{
			return GetHashCode() == other.GetHashCode();
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}