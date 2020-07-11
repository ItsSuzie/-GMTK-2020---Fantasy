using UnityEngine;
using System.IO;

public class BrainFreeze : MonoBehaviour
{
    [Range(0, 1)] public float speedDecreaseMultiplier = 0.5f;
    private fileIOManager io;
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
    }

    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "BrainFreeze(*)");
        if(files.Length > 0)
        {
            playerMovement.SetBrainFreeze(true, speedDecreaseMultiplier);
        }
        else if(files.Length == 0)
        {
            playerMovement.SetBrainFreeze(false, speedDecreaseMultiplier);
        }
    }



}
