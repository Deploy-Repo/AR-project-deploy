using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VideoRetrieval : MonoBehaviour
{
    public string folderPath;
    public string[] videoFiles;


    private void Start()
    {
        VideoLoad();
    }

    void VideoLoad()
    {
        videoFiles = Directory.GetFiles(folderPath, "*.mp4");
    }
}
