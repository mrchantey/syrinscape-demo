using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

namespace SyrinscapeDemo
{

	public class BulletCollisionSystem : ComponentSystem
	{

		EntityQuery scoreQuery;

		protected override void OnCreate()
		{
			scoreQuery = GetEntityQuery(new EntityQueryDesc
			{
				All = new[] { ComponentType.ReadWrite<Score>() },
			});
			RequireForUpdate(scoreQuery);
			base.OnCreate();
		}

		protected override void OnUpdate(EntityCommandBuffer commandBuffer)
		{
			var maxRadius = 0.5f;
			var maxRadiusSqr = maxRadius * maxRadius;
			var enemies = new List<(Entity, Translation)>();
			Entities
			.WithoutBurst()
			.ForEach((Entity entity, ref Enemy enemy, ref Translation translation) => enemies.Add((entity, translation))).Run();

			var bullets = new List<(Entity, Translation)>();
			Entities
			.WithoutBurst()
			.ForEach((Entity entity, ref Bullet bullet, ref Translation translation) => bullets.Add((entity, translation))).Run();

			var score = SingletonEntity.GetSharedComponentData<Score>();

			bullets.ForEach(bullet =>
			{
				var posA = bullet.Item2.Value;
				enemies.ForEach(enemy =>
				{
					var posB = enemy.Item2.Value;
					var dist = Mathf.Abs((posA.x - posB.x) * (posA.x - posB.x) + (posA.y - posB.y) * (posA.y - posB.y) + (posA.z - posB.z) * (posA.z - posB.z));
					if (dist < maxRadiusSqr)
					{
						commandBuffer.DestroyEntity(bullet.Item1);
						commandBuffer.DestroyEntity(enemy.Item1);
						score.score++;
						score!.text.text = $"Score: {score.score}";

						SingletonEntity.SetSharedComponentData(score);
					}
				});
			});
		}
	}
}