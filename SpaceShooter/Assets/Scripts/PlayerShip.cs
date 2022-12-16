using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class PlayerShip : MonoBehaviour
{
    private float speed = 10f;
    private float timer;
    private float reloadTime = 0.5f;

    [SerializeField] private GameObject lazerPrefab;

    private Entity lazerEntity;
    private EntityManager entityManager;
    private BlobAssetStore blobAssetStore;

    void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        blobAssetStore = new BlobAssetStore();
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore);
        lazerEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(lazerPrefab, settings);

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
            var newLazer = entityManager.Instantiate(lazerEntity);
            entityManager.SetComponentData(newLazer, new Translation { Value = transform.position });

            timer = reloadTime;
        }
    }
}
