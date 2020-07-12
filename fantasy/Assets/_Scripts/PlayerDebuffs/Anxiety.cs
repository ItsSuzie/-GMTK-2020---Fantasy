using UnityEngine;
using System.IO;

public class Anxiety : MonoBehaviour
{
    private bool deafFound = false;
    private fileIOManager io;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCombatController playerCombat;
    public Vector2 anxietyTimerRandom; // for how long anxiety lasts
    [SerializeField] private float AnxietyTimer;         // timer for how long anxiety lasts
    public Vector2 AnxietyDelayRandom;
    [SerializeField] private float AnxietyDelayTimer;

    private float getDebuffInterval(Vector2 timeInterval)
    {
        return Random.Range(timeInterval.x, timeInterval.y);
    }

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();

        AnxietyTimer = getDebuffInterval(anxietyTimerRandom);
    }
    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "Anxiety(*)");
        if(files.Length > 0)
        {
            // Delay before anxiety hits
            if (AnxietyDelayTimer > 0 && AnxietyTimer <= 0)
            {
                AnxietyDelayTimer -= Time.deltaTime;
                if (AnxietyDelayTimer <= 0)
                {
                    AnxietyTimer = getDebuffInterval(anxietyTimerRandom);
                }
            }
            // Countdowns debuff interval timer
            if(AnxietyTimer > 0 && AnxietyDelayTimer <= 0)
            {
                AnxietyTimer -= Time.deltaTime;

                playerMovement.SetNoMove = true;
                playerCombat.DebuffSetAnxietyNoCombat = true;

                // When 0, stop debuff, set delay
                if(AnxietyTimer <= 0)
                {
                    playerMovement.SetNoMove = false;
                    playerCombat.DebuffSetAnxietyNoCombat = false;

                    // AnxietyTimer = getDebuffInterval(anxietyTimerRandom);
                    AnxietyDelayTimer = getDebuffInterval(AnxietyDelayRandom);
                }
            }
        }
        
    }
}
