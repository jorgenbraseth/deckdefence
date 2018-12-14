using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Spawning;
    public float spawnRate = 0.5f;
    public float nextSpawn;
    
    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if(Time.time < nextSpawn)
            return;
        
        Instantiate(Spawning, transform.position, Quaternion.identity);
        nextSpawn = Time.time + 1f / spawnRate;
    }
}
