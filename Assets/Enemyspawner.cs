using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject Enemy;
    float randX;
    Vector2 WheretoSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(15.8f, 143.5f);
            WheretoSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy, WheretoSpawn, Quaternion.identity);
        }
    }
}
