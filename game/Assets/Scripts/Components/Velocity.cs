using System;
using Unity.Entities;
using UnityEngine;

namespace SyrinscapeDemo
{

	[Serializable]
	[GenerateAuthoringComponent]
	public struct Velocity : IComponentData
	{
		public Vector3 value;
	}
}

