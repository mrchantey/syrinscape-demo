using Unity.Entities;
using UnityEngine;

namespace SyrinscapeDemo
{

	public class SingletonEntity : SystemBase
	{


		static World world;
		static Entity entity;

		public static T GetComponentData<T>() where T : struct, IComponentData => world.EntityManager.GetComponentData<T>(entity);
		public static T GetSharedComponentData<T>() where T : struct, ISharedComponentData => world.EntityManager.GetSharedComponentData<T>(entity);
		public static void AddComponentData<T>(T data) where T : struct, IComponentData => world.EntityManager.AddComponentData<T>(entity, data);
		public static void AddSharedComponentData<T>(T data) where T : struct, ISharedComponentData => world.EntityManager.AddSharedComponentData<T>(entity, data);
		public static void SetComponentData<T>(T data) where T : struct, IComponentData => world.EntityManager.SetComponentData<T>(entity, data);
		public static void SetSharedComponentData<T>(T data) where T : struct, ISharedComponentData => world.EntityManager.SetSharedComponentData<T>(entity, data);

		protected override void OnCreate()
		{
			world = World;
			entity = World.EntityManager.CreateEntity();
		}

		protected override void OnUpdate() { }
	}
}