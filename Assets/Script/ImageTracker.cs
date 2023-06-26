using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ImageTracker : MonoBehaviour
{
    [System.Serializable]
    public class TrackedImageVideoPair
    {
        public string imageName;
        public GameObject prefab;
    }

    public ARTrackedImageManager trackedImageManager;
    public TrackedImageVideoPair[] trackedImageVideoPairs;

    private Dictionary<string, GameObject> spawnedObjects;

    private void Awake()
    {
        spawnedObjects = new Dictionary<string, GameObject>();
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            foreach (var pair in trackedImageVideoPairs)
            {
                if (trackedImage.referenceImage.name == pair.imageName)
                {
                    GameObject instantiatedPrefab = Instantiate(pair.prefab, trackedImage.transform);
                    spawnedObjects.Add(trackedImage.referenceImage.name, instantiatedPrefab);

                    instantiatedPrefab.SetActive(true);

                    VideoPlayer videoPlayer = instantiatedPrefab.GetComponentInChildren<VideoPlayer>(true);
                    if (videoPlayer != null)
                    {
                        videoPlayer.Play();
                    }
                    else
                    {
                        Debug.LogWarning("VideoPlayer component not found in the instantiated prefab's children.");
                    }
                    break;
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (spawnedObjects.ContainsKey(trackedImage.referenceImage.name))
            {
                GameObject spawnedObject = spawnedObjects[trackedImage.referenceImage.name];
                spawnedObject.transform.position = trackedImage.transform.position;
                spawnedObject.transform.rotation = trackedImage.transform.rotation;

                spawnedObject.SetActive(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking);
            }
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            if (spawnedObjects.ContainsKey(trackedImage.referenceImage.name))
            {
                GameObject spawnedObject = spawnedObjects[trackedImage.referenceImage.name];
                Destroy(spawnedObject);
                spawnedObjects.Remove(trackedImage.referenceImage.name);
            }
        }
    }
}