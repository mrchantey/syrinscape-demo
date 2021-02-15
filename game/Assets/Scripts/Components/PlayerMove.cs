using System;
using Unity.Entities;
using UnityEngine;

namespace SyrinscapeDemo
{

	[Serializable]
	[GenerateAuthoringComponent]
	public struct PlayerMove : IComponentData
	{
		public float speed;
	}
}