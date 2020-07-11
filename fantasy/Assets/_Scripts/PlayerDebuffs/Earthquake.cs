using UnityEngine;
using System.IO;

public class Earthquake : MonoBehaviour
{    
    private fileIOManager io;
    [SerializeField] private CamEarthquake camEQ;

    private bool vertigoFound = false;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
    }

    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "EarthQuake(*)");
        if(files.Length > 0)
        {
            camEQ.enabled = true;
        }
        else if (files.Length == 0)
        {
            camEQ.enabled = false;
        }
    }
}
