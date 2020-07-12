using UnityEngine;
using UnityEngine.SceneManagement;

public class gmtktomenutransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void loadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
