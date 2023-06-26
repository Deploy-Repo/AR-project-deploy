using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

public class VideoAppear : MonoBehaviour
{/*
    public string folderPath;
    public VideoClip[] videoClips;
    private readonly object DownloadHandlerVideoClip;

    void Start()
    {
        string[] videoFiles = Directory.GetFiles(folderPath, "*.mp4");
        videoClips = new VideoClip[videoFiles.Length];

        for (int i = 0; i < videoFiles.Length; i++)
        {
            string filePath = videoFiles[i];
            StartCoroutine(LoadVideoClip(filePath, i));
        }
    }

    IEnumerator LoadVideoClip(string filePath, int index)
    {
        string videoPath = "file://" + Path.GetFullPath(filePath);
        UnityWebRequest www = UnityWebRequestMultimedia.GetMovieTexture(videoPath);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error loading video: " + www.error);
            yield break;
        }

        VideoClip videoClip = DownloadHandlerVideoClip.GetContent(www);
        videoClips[index] = videoClip;

        // Use the video clip here, e.g., play it on a VideoPlayer component
        VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.clip = videoClips[index];
        videoPlayer.Play();
    }*/
}
