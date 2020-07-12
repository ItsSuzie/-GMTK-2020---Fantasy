using UnityEngine;

public class PlayerDebuffController : MonoBehaviour
{
    // Variables
    public Vector2 MinMaxDebuffIntervalSeconds;
    [SerializeField] private float debuffIntervalTimer;
    private fileIOManager IOManager;

    private float getDebuffInterval()
    {
        return Random.Range(MinMaxDebuffIntervalSeconds.x, MinMaxDebuffIntervalSeconds.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        IOManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<fileIOManager>();
        debuffIntervalTimer = getDebuffInterval();
    }

    // Update is called once per frame
    void Update()
    {
        // Countdowns debuff interval timer
        if(debuffIntervalTimer > 0)
        {
            debuffIntervalTimer -= Time.deltaTime;

            // When 0, activate debuff
            if(debuffIntervalTimer <= 0)
            {
                debuffIntervalTimer = getDebuffInterval();

                // Create random debuff;
                IOManager.createFileFromDebuffListRandom();
            }
        }
    }
}
