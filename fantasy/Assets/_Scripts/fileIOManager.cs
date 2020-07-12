using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Diagnostics;
using UnityEngine;

public class fileIOManager : MonoBehaviour
{

    #region Variables

    public List<string> debuffFileNames;

    public List<string> mainHealthFileNames = new List<string> {"Health(1)", "Health(2)", "Health(3)"};    

    public List<string> audioGlitchFiles = new List<string> {"Glitch(1)", "Glitch(2)"};

    private string[] files;

    public string rootFilePath;     // The file path root directory where the files will be stored
    private string filePath;        // the whole file path
    private audioManager audioManager;

    #endregion


    private void Awake()
    {
        audioManager = GetComponent<audioManager>();

        // Sets the path where all the files will live
        filePath = Application.dataPath + rootFilePath;

        

        DeleteDirectory();
        createDirectory();


        Process.Start(@filePath);
        string readmePath = filePath + "/README.forest";
        // Create a file to write to.
        using (StreamWriter sw = File.CreateText(readmePath))
        {
            sw.WriteLine("\n\n\nYou are Wander");
            sw.WriteLine("You chose to get away from everyone");
            sw.WriteLine("Now you're alone in a dark forest");
            sw.WriteLine("Like you planned");
            sw.WriteLine("");
            sw.WriteLine("You're going insane");
            sw.WriteLine("You're hellucinating");
            sw.WriteLine("You're not in a good place");
            sw.WriteLine("Your mind wants to kill you");
            sw.WriteLine("");
            sw.WriteLine("Survive as long as you can by fighting off the monsters in this forest");
            sw.WriteLine("and by fighting off the monsters in your mind");
            sw.WriteLine("");
            sw.WriteLine("");
            sw.WriteLine("This game requires you to delete files in the directory automatically opened for you");
            sw.WriteLine("You must work hard to fight off the enemies");
            sw.WriteLine("As well as fight off the monsters inside your head");
            sw.WriteLine("");
            sw.WriteLine("");
            sw.WriteLine("");

        }
        Process.Start(@"Notepad.exe", filePath + "/README.forest");
    }

    private void Update() {
        if (Directory.Exists(filePath)) {
            files = Directory.GetFiles(filePath);
        }
    }

    private void OnApplicationQuit()
    {
        DeleteDirectory();
    }

    #region fileManagement
    private int getRandInt(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public void DeleteDirectory()
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

    public void DeleteFile(string fileToDelete)
    {
        if(Directory.Exists(filePath))
        {
            File.Delete(filePath + fileToDelete);
        }
    }

    public bool isFileExists(string filename) {
        return Array.Exists(files, name => name == filename);
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
        // Debug.Log("Creating file " + fileToCreate + "(" + (fileCount + 1) + ")");
        File.CreateText(filePath + fileToCreate + "(" + (fileCount + 1) + ")");
    }

    public void createFileFromDebuffListRandom()
    {
        // Get random file
        int randInt;
        string fileToCreate;
        do 
        {
            randInt = getRandInt(0, debuffFileNames.Count);
            fileToCreate = debuffFileNames[randInt];
        }
        while(fileToCreate == "null");
        audioManager.playGlitchyClip(randInt);
        createFileFromString(fileToCreate);
    }

    public void createFileFromDeBuffListIndex(int i)
    {
        // get file from index
        string fileToCreate = debuffFileNames[i];
        audioManager.playGlitchyClip(i);
        createFileFromString(fileToCreate);
    }

    public void createFileFromMainHealthFileNamesRandom()
    {
        int randInt;
        string fileToCreate;
        do
        {
            randInt = getRandInt(0, mainHealthFileNames.Count);
            fileToCreate = mainHealthFileNames[randInt];
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

        // Debug.Log("Deleting File" + filePath + fileToCreate + "!");
        File.Delete(filePath + fileToCreate);
    }

    #endregion


    public string Path
    {
        get { return filePath; }
    }
}
