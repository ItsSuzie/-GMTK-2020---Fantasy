using UnityEngine;
using System.IO;

public class AdverseMovements : MonoBehaviour
{
    private bool adverseFound = false;
    public PlayerInputManager playerInput;
    private fileIOManager io;

    private void Start()
    {
        io = GetComponentInParent<fileIOManager>();
    }
    private void Update()
    {
        // string[] files = Directory.GetFiles(io.Path, "AdverseMovements(*)");
        // string[] files = io.getGroupFiles("AdverseMovements");
        // if (files.Length > 0)
        if(io.isFileWithSubStringExist(transform.name))
        {
            adverseFound = true;
            playerInput.setAdverse = true;
        }
        // else if (files.Length == 0)
        else
        {
            adverseFound = false;
            playerInput.setAdverse = false;
        }

    }
}
