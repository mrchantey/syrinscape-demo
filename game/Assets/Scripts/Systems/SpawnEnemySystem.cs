using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace SyrinscapeDemo
{

    public class SpawnEnemySystem : ComponentSystem
    {


        double lastTime;
        float xRange = 2;
        float yPos = 8;
        public bool spawnNextFrame;
        public int currentEnemey = 0;


        protected override void OnUpdate(EntityCommandBuffer commandBuffer)
        {
            var dt = Time.ElapsedTime - lastTime;

            var enemyOptions = SingletonEntity.GetSharedComponentData<EnemyOptions>();
            var renderMesh = World.EntityManager.GetSharedComponentData<RenderMesh>(enemyOptions.prefab);
            if (dt > enemyOptions.spawnFreq || spawnNextFrame)
            {
                var instance = commandBuffer.Instantiate(enemyOptions.prefab);
                // int index = Random.Range(0, enemyOptions.enemyTypes.Length);
                commandBuffer.SetComponent(instance, new Translation { Value = new Vector3(Random.Range(-xRange, xRange), 8, 0) });

                var renderMesh2 = renderMesh;
                renderMesh2.material = new Material(renderMesh.material);
                renderMesh2.material.SetTexture("_MainTex", enemyOptions.enemyTypes[currentEnemey].texture);
                commandBuffer.SetSharedComponent(instance, renderMesh2);

                lastTime = Time.ElapsedTime;
                spawnNextFrame = false;
            }
        }
    }
}