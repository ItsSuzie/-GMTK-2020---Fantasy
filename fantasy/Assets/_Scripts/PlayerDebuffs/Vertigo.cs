using UnityEngine;
using TMPro;
using System.IO;
using System.Text.RegularExpressions;
/// <Summary>
/// wobble camera gently left to right
/// </Summary>
public class Vertigo : MonoBehaviour
{
    public float wobbleSpeed = 2f;
    public float wobbleAmmount = 2f;
    public TextMeshProUGUI rot;
    private fileIOManager io;

    private bool vertigoFound = false;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
    }

    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "Vertigo(*)");
        // string pattern = "Vertigo(*)";
        // for (int i = 0; i < files.Length; ++i)
        if(files.Length > 0)
        {
            vertigoFound = true;
            rot.text = (Mathf.Cos(Time.time * wobbleSpeed) / wobbleAmmount).ToString();
            Camera.main.transform.Rotate(new Vector3(0, 0, Mathf.Cos(Time.time * wobbleSpeed) / wobbleAmmount));
            // break;
        }
        else
        {
            Camera.main.transform.Rotate(Vector3.zero);
            vertigoFound = false;
        }


            
        
    }
}
