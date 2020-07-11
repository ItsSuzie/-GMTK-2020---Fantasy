using UnityEngine;
using System;
using System.IO;

public class fileio_test : MonoBehaviour
{

    string path; 
    string pathfile;
    // Start is called before the first frame update
    void Awake()
    {
        #if UNITY_EDITOR
        path = Application.dataPath + "/forest/";
        pathfile = Application.dataPath + "/forest/helloworld";
        #endif

        #if UNITY_STANDALONE
        path = Application.dataPath + "/../forest/";
        pathfile = Application.dataPath + "/../forest/helloworld";
        #endif

        Debug.LogError(path);

        if(!Directory.Exists(path))     
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
        }  

        if (!File.Exists(pathfile))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(pathfile))
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
        if (!File.Exists(pathfile))
        {
            Debug.LogError("File does not exist: helloworld");
        }
        else
        {
            Debug.LogError("File exists: Helloworld");
        }
    }
}
