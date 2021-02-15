using UnityEngine;
using Unity.Entities;
using UnityEngine.SceneManagement;

namespace SyrinscapeDemo
{

	public class ConvertScene : MonoBehaviour
	{
		void Start()
		{
			var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
			// var activeScene = SceneManager.GetActiveScene();
			var settings = GameObjectConversionSettings.FromWorld(entityManager.World, null);
			// settings.ConversionFlags = GameObjectConversionUtility.
			// GameObjectConversionUtility.ConvertScene(activeScene, settings);
			GameObjectConversionUtility.ConvertGameObjectHierarchy(gameObject, settings);
			Destroy(gameObject);
		}
	}
}