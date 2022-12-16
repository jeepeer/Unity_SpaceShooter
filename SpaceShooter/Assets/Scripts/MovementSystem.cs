using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
public class MovementSystem : ComponentSystem
{
    float3 enemyPosition;
    Entity enemyEntity;

    float3 bulletPosition;
    Entity bulletEntity;
    protected override void OnUpdate()
    {
        Entities.WithAll<EnemyComponentTag>().ForEach((Entity enemy, ref Translation translation) =>
        {
            translation.Value.x -= 2 * Time.DeltaTime;
            enemyPosition = translation.Value;
            enemyEntity = enemy;

            if (math.distance(bulletPosition, enemyPosition) <= 1)
            {
                PostUpdateCommands.DestroyEntity(bulletEntity);
                PostUpdateCommands.DestroyEntity(enemyEntity);
            }
        });

        Entities.WithAll<BulletComponentTag>().ForEach((Entity bullet, ref Translation translation) =>
        {
            translation.Value.x += 1 * Time.DeltaTime;
            bulletPosition = translation.Value;
            bulletEntity = bullet;

            if (math.distance(bulletPosition, enemyPosition) <= 1)
            {
                PostUpdateCommands.DestroyEntity(enemyEntity);
                PostUpdateCommands.DestroyEntity(bulletEntity);
            }
        });


    }
}
