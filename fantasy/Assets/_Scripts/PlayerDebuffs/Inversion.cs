using UnityEngine;
using System.IO;

public class Inversion : MonoBehaviour
{

    private fileIOManager io;

    private bool inversionFound = false;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
    }
    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "Inversion(*)");
        if(files.Length > 0 && !inversionFound)
        {
            inversionFound = true;
            Camera.main.transform.Rotate(new Vector3(0, 0, 180));
            // break;
        }
        else
        {
            Camera.main.transform.Rotate(Vector3.zero);
            inversionFound = false;
        }
    }
}
