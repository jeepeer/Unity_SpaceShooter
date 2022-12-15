using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerEntity : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, Unity.Entities.EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentObject(entity, GetComponent<Transform>());
        dstManager.AddComponentObject(entity, GetComponent<MeshRenderer>());
        dstManager.AddComponentObject(entity, GetComponent<MeshFilter>());
    }
}