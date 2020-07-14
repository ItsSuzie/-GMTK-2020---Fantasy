using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Diagnostics;

public class MenuControl : MonoBehaviour
{
    public string rootFilePath = "/../forest/";     // The file path root directory where the files will be stored
    string filePath;
    private void Awake()
    {
        // Sets the path where all the files will live
        filePath = Application.dataPath + rootFilePath;

        
        DeleteDirectory();
        createDirectory();

        string readmePath;

        // Open explorer window for os to the path where the files will be
        Process.Start(@filePath);

        #if UNITY_STANDALONE_WIN
            readmePath = filePath + "/README.forest";

            using (StreamWriter sw = File.CreateText(readmePath))
            {
                sw.WriteLine("\n\n\nYou are Wander");
                sw.WriteLine("You chose to get away from everyone");
                sw.WriteLine("Now you're alone in a dark forest");
                sw.WriteLine("Like you planned");
                sw.WriteLine("");
                sw.WriteLine("You're going insane");
                sw.WriteLine("You're hallucinating");
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
                sw.Close();
            }
            Process.Start(@"Notepad.exe", readmePath);

        #endif
        
        #if UNITY_STANDALONE_OSX
            readmePath = filePath + "/README.txt";
            using (StreamWriter sw = File.CreateText(readmePath))
            {
                sw.WriteLine("\n\n\nYou are Wander");
                sw.WriteLine("You chose to get away from everyone");
                sw.WriteLine("Now you're alone in a dark forest");
                sw.WriteLine("Like you planned");
                sw.WriteLine("");
                sw.WriteLine("You're going insane");
                sw.WriteLine("You're hallucinating");
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
                sw.Close();
            }
            // Process.Start(@"/Applications/TextEdit.app/Contents/MacOS/TextEdit", readmePath);
        #endif

        #if UNITY_STANDALONE_LINUX
            readmePath = filePath + "/README.forest";
            using (StreamWriter sw = File.CreateText(readmePath))
            {
                sw.WriteLine("\n\n\nYou are Wander");
                sw.WriteLine("You chose to get away from everyone");
                sw.WriteLine("Now you're alone in a dark forest");
                sw.WriteLine("Like you planned");
                sw.WriteLine("");
                sw.WriteLine("You're going insane");
                sw.WriteLine("You're hallucinating");
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
                sw.Close();
            }
            Process.Start(filePath + readmePath);
        #endif
    }

    private void createDirectory()
    {
        if(!Directory.Exists(filePath))
        {
            DirectoryInfo di = Directory.CreateDirectory(filePath);
        }
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

    public void loadForest()
    {
        SceneManager.LoadScene("Forest");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void reloadForest()
    {
        fileIOManager io = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<fileIOManager>();
        io.DeleteDirectory();
        loadForest();
    }
}

