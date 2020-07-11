using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private bool isActive;

    [SerializeField] private GameObject enemyType;
    [SerializeField] private float spawnArea;

    [SerializeField] private int enemiesPerPoint;
    [SerializeField] private int enemyRandomness;
    [SerializeField] private int totalNumberOfEnemies;

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

            foreach (GameObject spawnPoint in enemySpawnPoints)
            {
                numOfEnemies = (enemiesPerPoint - enemyRandomness == 0) ? enemiesPerPoint + enemyRandomness() : 0; //im sorry eveyrone hates ternery but this looks pretty cleann

                for (int enemy = 1; enemy < numOfEnemies; enemy++)
                {
                    Instantiate(enemyType, new Vector2(spawnPoint.transform.position.x + Random.Range(spawnArea, -spawnArea), spawnPoint.position.y + Random.Range(spawnArea, -spawnArea)), Quaternion.identity);
                }
            }
            isActive = false;
        }

        if (totalNumberOfEnemies == 0) { 
            isActive = true;
        }
    }
}
