using Unity.Entities;
using Unity.Transforms;
using UnityEngine.InputSystem;
using UnityEngine;

namespace SyrinscapeDemo
{

	public class PlayerMoveSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var time = Time.DeltaTime;

			var kb = Keyboard.current;

			int xAxis = ((kb.aKey.isPressed || kb.leftArrowKey.isPressed) ? -1 : 0) +
				((kb.dKey.isPressed || kb.rightArrowKey.isPressed) ? 1 : 0);

			int yAxis = ((kb.wKey.isPressed || kb.upArrowKey.isPressed) ? 1 : 0)
			+ ((kb.sKey.isPressed || kb.downArrowKey.isPressed) ? -1 : 0);


			Entities.ForEach((ref PlayerMove move, ref Translation translation) =>
			{
				translation.Value.x += move.speed * time * xAxis;
				translation.Value.y += move.speed * time * yAxis;
			}).ScheduleParallel();
		}
	}
}