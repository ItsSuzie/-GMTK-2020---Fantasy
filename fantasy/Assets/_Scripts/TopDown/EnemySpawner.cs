using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool isActive;
    private bool initiateNameChange;

    // [HideInInspector] public float spawnRate;
    // private float SpawnRateTimer = 0;

    public Transform EnemyHolder;

    [SerializeField] private Enemy enemyType;
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
            initiateNameChange = true;

            GameObject[] enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoints");

            foreach (GameObject spawnPoint in enemySpawnPoints)
            {
                int numOfEnemies = (enemiesPerPoint - enemyRandomness > 0) ? enemiesPerPoint + Random.Range(enemyRandomness, -enemyRandomness) : enemiesPerPoint + Random.Range(0, enemyRandomness); //im sorry eveyrone hates ternery but this looks pretty cleann
                
                // if (SpawnRateTimer <= 0)
                // {
                for (int enemy = 1; enemy < numOfEnemies; enemy++)
                {
                    Enemy clone = Instantiate(enemyType, new Vector2(spawnPoint.transform.position.x + Random.Range(spawnArea, -spawnArea), spawnPoint.transform.position.y + Random.Range(spawnArea, -spawnArea)), Quaternion.identity);
                    clone.transform.SetParent(EnemyHolder);
                    // clone.nameSetter = GetComponent<EnemyNameSetter>();
                }
                // SpawnRateTimer = spawnRate;
                // }
            }
            isActive = false;
        }
        if (totalNumberOfEnemies == 0) { 
            isActive = true;
        }

        // Debug.Log("Total Number of Enemies: " + totalNumberOfEnemies.ToString() + " || enemyType.enemyCount: " + enemyType.enemyCount.ToString());


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
