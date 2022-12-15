using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class PlayerShip : MonoBehaviour
{
    private float speed = 10f;
    private float timer;
    private float reloadTime = 0.2f;

    public GameObject gameObject;

    private Entity entity;
    private EntityManager entityManager;
    private BlobAssetStore blobAssetStore;

    void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        blobAssetStore = new BlobAssetStore();
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore);
        entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(gameObject, settings);

        timer = reloadTime;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            var newLazer = entityManager.Instantiate(entity);
            entityManager.SetComponentData(newLazer, new Translation { Value = transform.position });

            //entityManager.AddComponentData(newLazer, new COMPONENT { Value = -1});

            timer = reloadTime;
        }
    }
}
