using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class fileIOManager : MonoBehaviour
{

    #region Variables

    public List<string> debuffFileNames;

    public List<string> mainHealthFileNames = new List<string> {"Health(1)", "Health(2)", "Health(3)"};    

    public string rootFilePath;     // The file path root directory where the files will be stored
    private string filePath;        // the whole file path

    #endregion


    private void Awake()
    {
        // Sets the path where all the files will live
        filePath = Application.dataPath + rootFilePath;

        // // If the file path does not exist, create that path
        // if(!Directory.Exists(filePath))
        // {
        //     DirectoryInfo di = Directory.CreateDirectory(filePath);
        // }
        // // if the directory exists already, delete everything in that directory
        // else
        // {
        //     string[] files = Directory.GetFiles(filePath);
        //     for(int i = 0; i < files.Length; ++i)
        //         File.Delete(files[i]);
        // }

        DeleteDirectory();
        createDirectory();
    }

    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.J))
        //     createFileFromDebuffListRandom();
        // if(Input.GetKeyDown(KeyCode.K))
        //     createFileFromMainHealthFileNamesRandom();
    }

    private void OnApplicationQuit()
    {
        DeleteDirectory();
    }

    #region fileManagement

    private void DeleteDirectory()
    {
        if(Directory.Exists(filePath))
        {
            string[] files = Directory.GetFiles(filePath);
            for(int i = 0; i < files.Length; ++i)
                File.Delete(files[i]);
            Directory.Delete(filePath);
        }
    }

    private void createDirectory()
    {
        if(!Directory.Exists(filePath))
        {
            DirectoryInfo di = Directory.CreateDirectory(filePath);
        }
    }




    public bool isFileExists(string filename) {
        return File.Exists(filePath + filename);
    }

    /// Create file assuming the file will not have duplicates.
    public void CreateFileFromStringNoDuplicates(string fileToCreate)
    {
        File.CreateText(filePath + fileToCreate);
    }

    public void createFileFromString(string fileToCreate)
    {
        // Get number of files of the same file
        if(fileToCreate == "null")
        {
            // dont create file, just return
            return;
        }
        int fileCount = Directory.GetFiles(filePath, fileToCreate + "(*)", SearchOption.TopDirectoryOnly).Length;
        Debug.Log("Creating file " + fileToCreate + "(" + (fileCount + 1) + ")");
        File.CreateText(filePath + fileToCreate + "(" + (fileCount + 1) + ")");
    }

    public void createFileFromDebuffListRandom()
    {
        // Get random file
        string fileToCreate;
        do 
        {
            fileToCreate = debuffFileNames[UnityEngine.Random.Range(0,debuffFileNames.Count)];
        }
        while(fileToCreate == "null");
        createFileFromString(fileToCreate);
    }

    public void createFileFromDeBuffListIndex(int i)
    {
        // get file from index
        string fileToCreate = debuffFileNames[i];
        createFileFromString(fileToCreate);
    }

    public void createFileFromMainHealthFileNamesRandom()
    {
        string fileToCreate;
        do
        {
            fileToCreate = mainHealthFileNames[UnityEngine.Random.Range(0, mainHealthFileNames.Count)];
        }
        while(fileToCreate == "null");
        createFileFromString(fileToCreate);
    }

    public void createFileFromMainHealthFileNamesIndex(int i)
    {
        string fileToCreate = mainHealthFileNames[i];
        createFileFromString(fileToCreate);
    }

    public void deleteFileFromString(string fileToCreate)
    {

        Debug.Log("Deleting File" + filePath + fileToCreate + "!");
        File.Delete(filePath + fileToCreate);
    }

    #endregion


    public string Path
    {
        get { return filePath; }
    }
}
