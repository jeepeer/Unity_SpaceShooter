using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class MovementSystem : ComponentSystem
{ 
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation trans, ref COMPONENT p) =>
        {
            trans.Value.x += p.Value * Time.DeltaTime;
        });

        Entities.ForEach((ref Translation trans, ref EEEEEEE p) =>
        {
            trans.Value.x -= p.Value * Time.DeltaTime;
        });
    }
}
