using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class EntitySpawner : ComponentSystem
{
    private float timer;
    private float x, y;
    protected override void OnUpdate()
    {
        timer -= Time.DeltaTime;
        if(timer <= 0f)
        {
            Entities.ForEach((ref EntityManagerComponent reflmao) =>
            {
                var lmao = EntityManager.Instantiate(reflmao.entity);
                EntityManager.SetComponentData(lmao, new Translation { Value = new float3(x,y,0)});
                x++;
                y++;
            });
        }
    }
}
