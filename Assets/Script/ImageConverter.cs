using System.IO;
using UnityEngine;

public class ImageConverter : MonoBehaviour
{
    /*public string folderPath = "C:/Users/ACER/AppData/LocalLow/DefaultCompany/ARProject/AR SAVES/ImageFolder";
    public Texture2D[] convertedTextures;

    [ContextMenu("Convert Raw Images")]

    public void Start()
    {
        ConvertRawImages();
    }
    public void ConvertRawImages()
    {
        string[] imageFiles = Directory.GetFiles(folderPath, "*.*");

        convertedTextures = new Texture2D[imageFiles.Length];

        for (int i = 0; i < imageFiles.Length; i++)
        {
            string imagePath = imageFiles[i];

            // Load the image as a Texture2D
            Texture2D texture = LoadTextureFromFile(imagePath);

            // Add the converted texture to the array
            convertedTextures[i] = texture;
        }
    }
    
    private Texture2D LoadTextureFromFile(string path)
    {
        Texture2D texture = new Texture2D(2, 2);
        byte[] fileData = File.ReadAllBytes(path);
        texture.LoadImage(fileData);

        // Get the file name without the extension
        string fileName = Path.GetFileNameWithoutExtension(path);

        // Set the name of the texture
        texture.name = fileName;

        return texture;
    }

    */
}
