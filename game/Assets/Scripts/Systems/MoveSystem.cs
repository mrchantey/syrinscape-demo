using Unity.Entities;
using UnityEngine;
using Unity.Transforms;

namespace SyrinscapeDemo
{

	public class MoveSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var dt = Time.DeltaTime;
			Entities.ForEach((ref Velocity velocity, ref Translation translation) =>
			{
				translation.Value.x += velocity.value.x * dt;
				translation.Value.y += velocity.value.y * dt;
				translation.Value.z += velocity.value.z * dt;
			}).ScheduleParallel();
		}
	}
}