using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArray : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100000; i++)
        {
            Instantiate(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
