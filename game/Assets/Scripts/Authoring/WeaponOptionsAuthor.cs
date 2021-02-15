using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;

namespace SyrinscapeDemo
{

	public class WeaponOptionsAuthor : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
	{
		public WeaponType[] weaponTypes;

		public GameObject prefab;

		public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
		{
			referencedPrefabs.Add(prefab);
		}

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var prefabEnt = conversionSystem.GetPrimaryEntity(prefab);
			SingletonEntity.AddSharedComponentData(new WeaponOptions()
			{
				weaponTypes = weaponTypes,
				prefab = prefabEnt
			});

			dstManager.DestroyEntity(entity);
		}

	}
}