using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forestMenu : MonoBehaviour
{
    public void reloadForest()
    {
        fileIOManager io = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<fileIOManager>();
        io.cleanDirectory();
        // io.DeleteDirectory();
        loadForest();
    }
        public void loadForest()
    {
        SceneManager.LoadScene("Forest");
    }
}
