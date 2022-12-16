using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class EntitySpawnSystem : ComponentSystem
{
    private float timer;
    private float3 spawnPosition;
    private float xPos;

    public bool test;

    protected override void OnStartRunning()
    {
        // set x for entity to be at the edge of the screen
        // /100 to go from pixel to Unity units
        xPos = (Screen.width) / 100;
    }

    protected override void OnUpdate()
    {
        timer -= Time.DeltaTime;
        if (timer <= 0f)
        {
            Entities.ForEach((ref EntityManagerComponent entityManagerComponent) =>
            {
                // instantiating entity prefab
                var entityReference = EntityManager.Instantiate(entityManagerComponent.entityPrefab);

                // set random y position for entity
                float randomYPos = (UnityEngine.Random.Range(-Screen.height, Screen.height)) / 100;
                spawnPosition = new float3(xPos, randomYPos, 0);
                EntityManager.SetComponentData(entityReference, new Translation { Value = spawnPosition });

                // reset timer
                timer = 0.1f;
            });
        }
    }
}
