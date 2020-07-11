using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningMissiles : MonoBehaviour
{

    public GameObject prefabToSpawn;
    public float spawnTime;
    public float spawnTimeRandom;

    private float spawnTimer;


    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTimer();
    }

    //Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            ResetSpawnTimer();
        }
    }

    //Resets the spawn timer with a random offset
    void ResetSpawnTimer()
    {
        spawnTimer = spawnTime;
    }
}









