using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class fileIOManager : MonoBehaviour
{

    #region Variables

    public List<string> debuffFileNames;  
    public List<string> mainHealthFileNames;

    public string rootFilePath;
    private string filePath;

    #endregion


    private void Start()
    {
        // Sets the path where all the files will live
        filePath = Application.dataPath + rootFilePath;

        // If the file path does not exist, create that path
        if(!Directory.Exists(filePath))
        {
            DirectoryInfo di = Directory.CreateDirectory(filePath);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            createFileFromString("myFile");  
    }


    #region fileManagement

    public void createFileFromString(string fileToCreate)
    {
        // Get number of files of the same file
        int fileCount = Directory.GetFiles(filePath, fileToCreate + "(*)", SearchOption.TopDirectoryOnly).Length;
        Debug.Log("Creating file " + fileToCreate + "(" + (fileCount + 1) + ")");
        File.CreateText(filePath + fileToCreate + "(" + (fileCount + 1) + ")");
    }
    




    #endregion

}
