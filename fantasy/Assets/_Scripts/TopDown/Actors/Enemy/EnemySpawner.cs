using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private bool isActive = true;

    [HideInInspector] public float spawnRate;
    private float SpawnRateTimer = 0;

    [SerializeField] private Enemy enemyType;
    [SerializeField] private Transform enemyHolder;
    [SerializeField] private float spawnArea;

    [SerializeField] private int numberOfEnemies;
    [SerializeField] private int enemyRandomness;
    private int totalNumberOfEnemies;

    [SerializeField] private float setpointDelay;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
    }   

    // Update is called once per frame
    void Update()
    {


        totalNumberOfEnemies = enemyType.enemyCount;

        if (isActive) 
        {
            GameObject[] enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoints");

            for (int enemy = 0; enemy < numberOfEnemies; enemy++)
            {
                GameObject spawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length - 1)];
                Enemy clone = Instantiate(enemyType, new Vector2(spawnPoint.transform.position.x + Random.Range(spawnArea, -spawnArea), spawnPoint.transform.position.y + Random.Range(spawnArea, -spawnArea)), Quaternion.identity);
                clone.transform.SetParent(enemyHolder);
                SpawnRateTimer = spawnRate;
                // }
            }
            isActive = false;
        }

        else if (totalNumberOfEnemies == 0) { 
            isActive = true;
        }

        Debug.Log("Total Number of Enemies: " + totalNumberOfEnemies.ToString() + " || enemyType.enemyCount: " + enemyType.enemyCount.ToString());


        // Might look into this later

        // if(SpawnRateTimer > 0)
        // {
        //     SpawnRateTimer -= Time.deltaTime;
        //     // if (SpawnRateTimer <= 0)
        //     // {
        //     //     SpawnRateTimer = spawnRate;
        //     // }
        // }

    }
}
