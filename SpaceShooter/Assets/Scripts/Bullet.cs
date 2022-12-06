using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int normal;
    Vector3 shootingDirection = Vector3.zero;
    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(shootingDirection * speed * Time.deltaTime);
    }

    public void HandleBulletDirection(int yNormal)
    {
        if(yNormal < 0)
        {
            shootingDirection = -Vector3.up;
        }
        else 
        {
            shootingDirection = Vector3.up;
        }
    }
    public enum BulletDirection
    {
        up = 1,
        down = -1
    };


    void AABB()
    {
        // only checks if it's colliding with anything
        // if it collides with an enemy or player it will deal damage and 
        // get destroyed.
    }
}
