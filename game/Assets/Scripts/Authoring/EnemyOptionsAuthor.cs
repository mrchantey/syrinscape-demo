using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;

namespace SyrinscapeDemo
{

	public class EnemyOptionsAuthor : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
	{

		public EnemyOptions options;
		// public EnemyType[] enemyTypes;
		public GameObject prefab;

		public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs) => referencedPrefabs.Add(prefab);

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var prefabEnt = conversionSystem.GetPrimaryEntity(prefab);
			options.prefab = prefabEnt;
			// var options2 = new EnemyOptions()
			// {
			// 	prefab = options.prefab,
			// 	spawnFreq = options.spawnFreq,
			// 	enemyTypes = options.enemyTypes
			// };
			SingletonEntity.AddSharedComponentData(options);
			// SingletonEntity.AddSharedComponentData(options2);
			dstManager.DestroyEntity(entity);
		}
	}
}