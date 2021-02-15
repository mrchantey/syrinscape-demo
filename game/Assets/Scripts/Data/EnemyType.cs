using UnityEngine;

namespace SyrinscapeDemo
{

	[CreateAssetMenu(fileName = "EnemyType", menuName = "SyrinscapeDemo/EnemyType", order = 0)]
	public class EnemyType : ScriptableObject
	{
		public Texture texture;
	}
}