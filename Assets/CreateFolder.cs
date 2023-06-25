using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CreateFolder : MonoBehaviour
{
    private void Start()
    {
        string folderPath = "Assets/NewFolder";

        // Check if the folder exists
        if (!Directory.Exists(folderPath))
        {
            // Create the folder if it doesn't exist
            Directory.CreateDirectory(folderPath);
            Debug.Log("Folder created: " + folderPath);
        }
        else
        {
            Debug.Log("Folder already exists: " + folderPath);
        }
    }
}
