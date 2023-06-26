using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ARManager : MonoBehaviour
{
    public string folderPath = "Assets/Textures";

    private struct TextureData
    {
        public Texture2D texture;
        public string fileName;
    }

    private List<TextureData> textureDataList = new List<TextureData>();

    void Start()
    {
        LoadTextures();
    }

    private void LoadTextures()
    {
        DirectoryInfo directory = new DirectoryInfo(folderPath);
        foreach (FileInfo file in directory.GetFiles("*.png"))
        {
            byte[] fileData = File.ReadAllBytes(file.FullName);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            TextureData textureData = new TextureData();
            textureData.texture = texture;
            textureData.fileName = file.Name;
            textureDataList.Add(textureData);
        }

        // Use the loaded textures and their corresponding file names as needed
        foreach (TextureData textureData in textureDataList)
        {
            Texture2D texture = textureData.texture;
            string fileName = textureData.fileName;

            // Perform operations with the texture and file name
            Debug.Log("Loaded texture: " + fileName);
        }
    }
}
