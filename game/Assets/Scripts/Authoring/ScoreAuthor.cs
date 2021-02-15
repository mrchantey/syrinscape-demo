using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;

namespace SyrinscapeDemo
{

	public class ScoreAuthor : MonoBehaviour, IConvertGameObjectToEntity
	{

		public Score score;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			SingletonEntity.AddSharedComponentData(score);
			dstManager.DestroyEntity(entity);
		}

	}

}