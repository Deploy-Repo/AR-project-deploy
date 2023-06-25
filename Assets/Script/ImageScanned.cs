using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

using UnityEngine.XR.ARFoundation.Samples;

public class ImageScanned : MonoBehaviour
{
    //public TrackedImageInfoManager boolean;
    public string folderName;
    public VideoPlayer vidPlayer;

    
    public VideoClip[] videoClips;
    public int currentClipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //boolean = GameObject.Find("XR Origin").GetComponent<TrackedImageInfoManager>();
        vidPlayer = GameObject.Find("Plane").GetComponent<VideoPlayer>();
        LoadVideoClips();
        //PlayNextVideo();
    }

    // Update is called once per frame
    void Update()
    {
        //boolean = GameObject.Find("XR Origin").GetComponent<TrackedImageInfoManager>();
        vidPlayer = GameObject.Find("Quad").GetComponent<VideoPlayer>();
        LoadVideoClips();
    }

    public void LoadVideoClips()
    {
        videoClips = Resources.LoadAll<VideoClip>(folderName);
    }

    public void PlayNextVideo()
    {
        if (currentClipIndex < videoClips.Length)
        {
            vidPlayer.clip = videoClips[currentClipIndex];
            vidPlayer.Play();
            currentClipIndex++;
        }
    }
}
