using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceShip : MonoBehaviour
{

    public float speed;
   

    void Start()
    {
    }

    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // add bullet to array, 
        // bullet array moves the bullets ?
    }
}