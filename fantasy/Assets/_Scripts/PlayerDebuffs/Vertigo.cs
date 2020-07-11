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
    private Camera cam;

    private bool vertigoFound = false;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
        cam = Camera.main;
    }

    private void Update()
    {
        string[] files = Directory.GetFiles(io.Path, "Vertigo(*)");
        if(files.Length > 0)
        {
            vertigoFound = true;
            cam.transform.Rotate(new Vector3(0, 0, Mathf.Sin(Time.time * wobbleSpeed) / wobbleAmmount));
        }
        else if (files.Length == 0)
        {
            cam.transform.rotation = Quaternion.identity;
            vertigoFound = false;
        }
    }
}
