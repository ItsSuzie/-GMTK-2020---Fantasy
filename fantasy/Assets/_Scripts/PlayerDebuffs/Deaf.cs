using UnityEngine;
using System.IO;

public class Deaf : MonoBehaviour
{
    private bool deafFound = false;
    private fileIOManager io;
    private AudioListener al;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
        al = Camera.main.GetComponent<AudioListener>();
    }
    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "Deaf(*)");
        if(files.Length > 0 && !deafFound)
        {
            deafFound = true;
            al.enabled = false;
        }
        else if (files.Length == 0)
        {
            deafFound = false;
            al.enabled = true;
        }
    }
}
