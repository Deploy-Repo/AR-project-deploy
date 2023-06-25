using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class EnabledReadandWrite : MonoBehaviour
{/*
    public string folderPath; // Specify the folder path containing the images in the Unity Inspector

    void Start()
    {
        EnableReadWriteForImages();
    }

    void EnableReadWriteForImages()
    {
        string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // PNG files
        imagePaths = imagePaths.Concat(Directory.GetFiles(folderPath, "*.jpg")).ToArray(); // JPG files
        imagePaths = imagePaths.Concat(Directory.GetFiles(folderPath, "*.jpeg")).ToArray(); // JPEG files

        foreach (string imagePath in imagePaths)
        {
            TextureImporter textureImporter = AssetImporter.GetAtPath(imagePath) as TextureImporter;
            if (textureImporter != null)
            {
                textureImporter.isReadable = true;
                AssetDatabase.ImportAsset(imagePath);
            }
        }
    }*/
}