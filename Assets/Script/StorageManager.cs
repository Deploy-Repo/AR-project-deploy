using UnityEngine;
using UnityEngine.Video;
using System.IO;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;



public class StorageManager : MonoBehaviour
{
    public DynamicLibrary DynamicLib;
    [Header("TextField Insert DataPath")]
    [SerializeField] private InputField imagetextfield;
    [SerializeField] private InputField videotextfield;
    [Header("Data Path")]
    public string imageFolderPath;
    public string videoFolderPath;

    [Header("Data from DataPath")]
    public string[] DataImage; 
    public string[] DataVideo;

    [Header("Loaded Assets")]
    public Texture2D[] imageFileNames;
    public string[] videoFileNames;
    private void Start()
    {
        CreateFolder();
        datapath();
        //DeleteDatainDataPathFolder();
        LoadRawImages();
        VideoLoad();
        DynamicLib.SetDatatoDynamicLib();
        DynamicLib.StateADDIMAGE();
    }
    void VideoLoad()
    {
        videoFileNames = Directory.GetFiles(videoFolderPath, "*.mp4");
    }
    public void datapath()
    {
        imageFolderPath = Path.Combine(Application.persistentDataPath, "AR SAVES", "ImageFolder");
        videoFolderPath = Path.Combine(Application.persistentDataPath, "AR SAVES", "VideoFolder");
    }
    public void InitiateCopyBTN()
    {
        InsertDATA();
        LoadRawImages();
        VideoLoad();

    }
    public void LoadRawImages()
    {
        
        string[] imageFiles = Directory.GetFiles(imageFolderPath, "*.*");

        imageFileNames = new Texture2D[imageFiles.Length];

        for (int i = 0; i < imageFiles.Length; i++)
        {
            string imagePath = imageFiles[i];

            // Load the image as a Texture2D
            Texture2D texture = LoadTexture2D(imagePath);

            // Add the converted texture to the array
            imageFileNames[i] = texture;
        }
    }
    private Texture2D LoadTexture2D(string path)
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
    public void CreateFolder()
    {
        string imageFolderPathname = Path.Combine(Application.persistentDataPath, "AR SAVES", "ImageFolder");
        string videoFolderPathname = Path.Combine(Application.persistentDataPath, "AR SAVES", "VideoFolder");
        Directory.CreateDirectory(imageFolderPathname);

        Debug.Log("Image folder created: " + imageFolderPathname);

        Directory.CreateDirectory(videoFolderPathname);

        Debug.Log("Video folder created: " + videoFolderPathname);

    }

    public void DeleteDatainDataPathFolder()
    {
        // Delete previous image files
        string[] previousImageFiles = Directory.GetFiles(imageFolderPath);
        foreach (string previousImageFile in previousImageFiles)
        {
            File.Delete(previousImageFile);
        }

        // Delete previous video files
        string[] previousVideoFiles = Directory.GetFiles(videoFolderPath);
        foreach (string previousVideoFile in previousVideoFiles)
        {
            File.Delete(previousVideoFile);
        }

        Debug.Log("Previous data in AppDataPath folder deleted.");
    }
    public void InsertDATA()
    {
        string externalStoragePath = Path.Combine(Application.persistentDataPath, "AR SAVES");

        string imageFolderPath = Path.Combine(externalStoragePath, "ImageFolder");
        string videoFolderPath = Path.Combine(externalStoragePath, "VideoFolder");
        
        foreach (string images in DataImage)
        {
            string fileName = Path.GetFileName(images);
            string imgfilename = fileName;
            string destinationPath = Path.Combine(imageFolderPath, imgfilename);
            File.Copy(images, destinationPath, true);
            Debug.Log(destinationPath);

        }

        #region For Test Only (rename Video Script)
        /*
        foreach (string image in DataImage)
        {
            string imageFileName = Path.GetFileName(image);
            string destinationImagePath = Path.Combine(imageFolderPath, imageFileName);
            File.Copy(image, destinationImagePath, true);
            Debug.Log(destinationImagePath);

            string correspondingVideo = DataVideo.FirstOrDefault();
            if (correspondingVideo != null)
            {
                string videoExtension = Path.GetExtension(correspondingVideo);

                // Get user input for the new video file name
                string newVideoFileName = "NewVideoName"; // Replace "NewVideoName" with the desired user input

                string videoFileName = newVideoFileName + videoExtension;
                string destinationVideoPath = Path.Combine(videoFolderPath, videoFileName);
                File.Copy(correspondingVideo, destinationVideoPath, true);
                Debug.Log(destinationVideoPath);
            }
        }
        */
        #endregion

        
        foreach (string videos in DataVideo)
        {
            string fileName = Path.GetFileName(videos);
            string videofilename = fileName; // for test only
            string destinationPath = Path.Combine(videoFolderPath, videofilename); // for test only                                                                     //string destinationPath1 = Path.Combine(videoFolderPath, fileName1);
            File.Copy(videos, destinationPath, true);
            Debug.Log(destinationPath);

        }
        
        Debug.Log("Data copied to Appdata folder.");
    }

    public void AddBtn()
    {
        List<string> dataImage = new List<string>();
        List<string> dataVideo = new List<string>();
        for (int i = 0; i < DataImage.Length; i++)
        {
            dataImage.Add(imagetextfield.text);
            Debug.Log(i);
        }
        // Add element to DataImage array
        Array.Resize(ref DataImage, DataImage.Length + 1); // Resize the array
        DataImage[DataImage.Length - 1] = imagetextfield.text; // Assign the new element to the last index

        for (int j = 0; j < DataVideo.Length; j++)
        {
            dataVideo.Add(videotextfield.text);
            Debug.Log(j);
        }
        // Add element to DataVideo array
        Array.Resize(ref DataVideo, DataVideo.Length + 1); // Resize the array
        DataVideo[DataVideo.Length - 1] = videotextfield.text; // Assign the new element to the last index

        Debug.Log("New element added to DataImage and DataVideo arrays.");
    }

}