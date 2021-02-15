using Unity.Entities;
using Unity.Transforms;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

namespace SyrinscapeDemo
{

	public abstract class JobSystem : SystemBase
	{

		// EndSimulationEntityCommandBufferSystem commandBufferSystem;
		EntityCommandBufferSystem commandBufferSystem;

		protected override void OnCreate()
		{
			// begin simulation cbs ensures that instantiation and transformations take place in the same frame
			commandBufferSystem = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = commandBufferSystem.CreateCommandBuffer().AsParallelWriter();
			OnUpdate(commandBuffer);
			commandBufferSystem.AddJobHandleForProducer(Dependency);
		}
		protected abstract void OnUpdate(EntityCommandBuffer.ParallelWriter commandBuffer);
	}
}

