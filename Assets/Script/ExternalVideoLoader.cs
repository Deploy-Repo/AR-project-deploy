using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class ExternalVideoLoader : MonoBehaviour
{
    #region Getting Vid Using Name
    /*public string videoFileName;  // Name of the video file with extension
    public VideoPlayer videoPlayer;
    public string videoFilePath;

    void Start()
    {
        // Construct the full path to the video file
        videoFilePath = Path.Combine(Application.streamingAssetsPath, videoFileName);

        // Create a VideoPlayer component
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        // Set the videoPlayer's source to the streaming assets path
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoFilePath;

        // Prepare the videoPlayer and start playing
        videoPlayer.Prepare();
        videoPlayer.Play();
    }

    void Update()
    {
        Debug.Log(videoFilePath);
    }*/
    #endregion
    public string folderURL;  // URL of the folder containing the video clips
    public string[] videoFiles;
    public string folderPath;
    public string streamingAssetsPath;

    private IEnumerator Start()
    {
        // Get the full path to the streaming assets folder
        streamingAssetsPath = Application.streamingAssetsPath;

        // Combine the streaming assets path with the folder URL
        folderPath = Path.Combine(streamingAssetsPath, folderURL);

        // Get the array of video files in the folder
        videoFiles = Directory.GetFiles(folderPath, "*.mp4");

        // Iterate through each video file
        foreach (string videoFile in videoFiles)
        {
            // Construct the full URL of the video file
            string videoURL = Path.Combine(folderURL, Path.GetFileName(videoFile));

            // Create a VideoPlayer component
            VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();

            // Set the videoPlayer's source to the URL of the video file
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = Path.Combine(Application.streamingAssetsPath, videoURL);

            // Prepare the videoPlayer and wait until it's prepared
            videoPlayer.Prepare();

            while (!videoPlayer.isPrepared)
            {
                yield return null;
            }

            // Play the videoPlayer
            videoPlayer.Play();

            // Wait for the video to finish playing
            while (videoPlayer.isPlaying)
            {
                yield return null;
            }

            // Destroy the videoPlayer to clean up
            Destroy(videoPlayer);
        }
    }
}
