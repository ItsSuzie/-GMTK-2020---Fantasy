using UnityEngine;
using System.IO;

public class Nearsighted : MonoBehaviour
{
    private fileIOManager io;
    [SerializeField] private GameObject nearsightedGO;


    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
    }

    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "Nearsighted(*)");
        if(files.Length > 0)
        {
            nearsightedGO.SetActive(true);
        }
        else if (files.Length == 0)
        {
            nearsightedGO.SetActive(false);
        }
    }
}
