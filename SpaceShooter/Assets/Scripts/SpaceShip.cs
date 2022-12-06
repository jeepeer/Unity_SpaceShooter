using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceShip : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float speed;
    
    float timeToReload = 0.1f;
    float reloadTimer;
    
    void Start()
    {
        reloadTimer = timeToReload;
    }

    void Update()
    {
        reloadTimer -= Time.deltaTime;

        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp(speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveUp(-speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveRight(-speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight(speed);
        }
    }

    void MoveUp(float value)
    {
        transform.Translate(Vector3.up * value * Time.deltaTime);
    }
    void MoveRight(float value)
    {
        transform.Translate(Vector3.right * value * Time.deltaTime);
    }

    void HandleShooting()
    {
        if (Input.GetKey(KeyCode.L))
        {
            if(reloadTimer <= 0f)
            {
                Shoot();
                reloadTimer = timeToReload;
            }
        }
    }

    void Shoot()
    {
        Vector3 mypos = transform.position;
        Bullet newBullet = Instantiate(bullet, mypos, Quaternion.identity);
        newBullet.HandleBulletDirection((int)Bullet.BulletDirection.up);


        // add bullet to array, 
        // bullet array moves the bullets ?
    }
}