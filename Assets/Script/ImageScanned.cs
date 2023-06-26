using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

using UnityEngine.XR.ARFoundation.Samples;

public class ImageScanned : MonoBehaviour
{
    //public TrackedImageInfoManager boolean;
    //public string folderName;

    public StorageManager storageManager;
    public VideoPlayer vidPlayer;

    
    public VideoClip[] videoClips;
    public int currentClipIndex;

    // Start is called before the first frame update
    void Start()
    {
        //boolean = GameObject.Find("XR Origin").GetComponent<TrackedImageInfoManager>();
        vidPlayer = GameObject.Find("Plane").GetComponent<VideoPlayer>();
        //LoadVideoClips();
        //PlayNextVideo();
        storageManager = GetComponent<StorageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //boolean = GameObject.Find("XR Origin").GetComponent<TrackedImageInfoManager>();
        vidPlayer = GameObject.Find("Quad").GetComponent<VideoPlayer>();
        storageManager = GetComponent<StorageManager>();
        //LoadVideoClips();
    }

    //public void LoadVideoClips()
    //{
    //    videoClips = Resources.LoadAll<VideoClip>(folderName);
    //}

    public void PlayNextVideo(int index)
    {
        if(index >= 0 && index < storageManager.videoFileNames.Length)
        {
            index = currentClipIndex;
            vidPlayer.source = VideoSource.Url;
            vidPlayer.url = storageManager.videoFileNames[currentClipIndex];
            //vidPlayer.clip = videoClips[currentClipIndex];
            vidPlayer.Play();
        }
        else
        {
            Debug.LogError("Invalid video clip Index");
        }

        //if (currentClipIndex < videoClips.Length)
        //{
        //    vidPlayer.clip = videoClips[currentClipIndex];
        //    vidPlayer.Play();
        //    currentClipIndex++;
        //}
    }
}
