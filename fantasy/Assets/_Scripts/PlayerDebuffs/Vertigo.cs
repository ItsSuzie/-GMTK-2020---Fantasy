using UnityEngine;
using TMPro;
using System.IO;
/// <Summary>
/// wobble camera gently left to right
/// </Summary>
public class Vertigo : MonoBehaviour
{
    public float wobbleSpeed = 2f;
    public float wobbleAmmount = 2f;
    private fileIOManager io;

    private bool vertigoFound = false;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
    }

    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "Vertigo(*)");
        if(files.Length > 0)
        {
            vertigoFound = true;
            Camera.main.transform.Rotate(new Vector3(0, 0, Mathf.Sin(Time.time * wobbleSpeed) / wobbleAmmount));
        }
        else
        {
            Camera.main.transform.rotation = Quaternion.identity;
            vertigoFound = false;
        }
    }
}
