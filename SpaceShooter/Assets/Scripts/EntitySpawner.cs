using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class EntitySpawner : ComponentSystem
{
    private float timer;
    float3 spawnPosition;
    float xPos;
    int maxEntities = 100;

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
                var entityReference = EntityManager.Instantiate(entityManagerComponent.entity);

                // set random y position for entity
                float randomYPos = (UnityEngine.Random.Range(-Screen.height, Screen.height)) / 100;
                spawnPosition = new float3(xPos, randomYPos, 0);
                EntityManager.SetComponentData(entityReference, new Translation { Value = spawnPosition });

                //EntityManager.AddComponentData(entityReference, new EEEEEEE { Value = 1 });

                // reset timer
                timer = 0.5f;
            });
        }
    }
}
