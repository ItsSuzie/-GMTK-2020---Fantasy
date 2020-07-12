using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

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

