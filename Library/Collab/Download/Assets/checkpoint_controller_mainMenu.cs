using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class checkpoint_controller_mainMenu : MonoBehaviour
{
    public void ClearCheckPoints()
    {
        string path = Application.persistentDataPath + "/checkpoint.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write("");
        writer.Close();

        Debug.Log("New file created.");

    }
}
