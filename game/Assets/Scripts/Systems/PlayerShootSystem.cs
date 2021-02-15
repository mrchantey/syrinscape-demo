using Unity.Entities;
using Unity.Transforms;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;
using Unity.Rendering;

namespace SyrinscapeDemo
{

	public class PlayerShootSystem : ComponentSystem
	{

		public int currentWeapon = 0;

		protected override void OnUpdate(EntityCommandBuffer commandBuffer)
		{
			var kb = Keyboard.current;
			if (kb.spaceKey.wasPressedThisFrame)
			// if (kb.spaceKey.isPressed)
			{
				// var weaponOptions = World.GetOrCreateSystem<SingletonEntity>().GetSharedComponentData<WeaponOptions>();
				var weaponOptions = SingletonEntity.GetSharedComponentData<WeaponOptions>();
				Entities
				.WithoutBurst()
				.ForEach((ref PlayerMove move, ref Translation translation, in RenderMesh renderMesh) =>
			   {
				   var instance = commandBuffer.Instantiate(weaponOptions.prefab);
				   commandBuffer.SetComponent(instance, new Translation { Value = translation.Value });
				   var renderMesh2 = renderMesh;
				   renderMesh2.material = new Material(renderMesh.material);
				   renderMesh2.material.SetTexture("_MainTex", weaponOptions.weaponTypes[currentWeapon].texture);
				   commandBuffer.SetSharedComponent(instance, renderMesh2);
			   }).Run();
			}
		}
	}
}