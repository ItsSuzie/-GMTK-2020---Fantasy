using UnityEngine;
using System;
using System.IO;

public class fileio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError(Application.dataPath + "/../helloworld");
        string path = Application.dataPath + "/../helloworld";

        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
