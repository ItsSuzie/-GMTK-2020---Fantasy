using UnityEngine;
using System.IO;

public class Pacifism : MonoBehaviour
{
    private fileIOManager io;
    [SerializeField] private PlayerCombatController playerCombat;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
    }

    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "Pacifism(*)");
        if(files.Length > 0)
        {
            // Debug.Log("Player now pacifist");
            playerCombat.debuffPacifist = true;
        }
        else if (files.Length == 0)
        {
            // Debug.Log("Player can fight");
            playerCombat.debuffPacifist = false;
        }
    }
}
