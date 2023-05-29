/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;

public class ImageTracker : MonoBehaviour
{
    [System.Serializable]
    public class TrackedImageVideoPair
    {
        public string imageName;
        public GameObject prefab;
        public VideoPlayer videoPlayer;
    }
    private ObjectPool objectPool;
    public ARTrackedImageManager trackedImageManager;
    public TrackedImageVideoPair[] trackedImageVideoPairs;

    private void Awake()
    {
        objectPool = new ObjectPool(InstantiatePrefab);
        foreach (var pair in trackedImageVideoPairs)
        {
            objectPool.AddObject(pair.prefab, 1); // Prepopulate the object pool with the prefab
        }
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
                    GameObject instantiatedPrefab = Instantiate(pair.prefab);
                    instantiatedPrefab.transform.SetParent(trackedImage.transform);
                    instantiatedPrefab.transform.localPosition = Vector3.zero;
                    instantiatedPrefab.transform.localRotation = Quaternion.identity;

                    VideoPlayer videoPlayer = instantiatedPrefab.GetComponentInChildren<VideoPlayer>();
                    videoPlayer.Play();
                    break;
                }
                if (trackedImage.referenceImage.name != pair.imageName)
                {
                    Destroy(pair.prefab);
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            foreach (var pair in trackedImageVideoPairs)
            {
                if (trackedImage.referenceImage.name == pair.imageName)
                {
                    if (!pair.videoPlayer.isPlaying)
                        pair.videoPlayer.Play();
                    break;
                }
                if (trackedImage.referenceImage.name != pair.imageName)
                {
                    Destroy(pair.prefab);
                }
            }
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            foreach (var pair in trackedImageVideoPairs)
            {
                if (trackedImage.referenceImage.name == pair.imageName)
                {
                    
                    break;
                }
            }
        }

    }
    public GameObject InstantiatePrefab(GameObject prefab)
    {
        return Instantiate(prefab);
    }

    private class ObjectPool
    {
        private Dictionary<int, Queue<GameObject>> objectPoolDictionary;
        private System.Func<GameObject, GameObject> instantiateMethod;

        public ObjectPool(System.Func<GameObject, GameObject> instantiateMethod)
        {
            objectPoolDictionary = new Dictionary<int, Queue<GameObject>>();
            this.instantiateMethod = instantiateMethod;
        }

        public void AddObject(GameObject prefab, int initialCount)
        {
            if (!objectPoolDictionary.ContainsKey(prefab.GetInstanceID()))
            {
                Queue<GameObject> objectPoolQueue = new Queue<GameObject>();

                for (int i = 0; i < initialCount; i++)
                {
                    GameObject obj = instantiateMethod(prefab);
                    obj.SetActive(false);
                    objectPoolQueue.Enqueue(obj);
                }

                objectPoolDictionary.Add(prefab.GetInstanceID(), objectPoolQueue);
            }
        }

        public GameObject GetObject(GameObject prefab)
        {
            if (objectPoolDictionary.TryGetValue(prefab.GetInstanceID(), out Queue<GameObject> objectPoolQueue))
            {
                if (objectPoolQueue.Count > 0)
                {
                    GameObject obj = objectPoolQueue.Dequeue();
                    obj.SetActive(true);
                    return obj;
                }
                else
                {
                    GameObject obj = instantiateMethod(prefab);
                    return obj;
                }
            }

            return null;
        }
    }
}
*/

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

/*
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

                // Adjust scale to match the size of the tracked image
                Vector2 imageSize = trackedImage.referenceImage.size;
                Vector2 imageScale = new Vector2(imageSize.x / spawnedObject.transform.localScale.x, imageSize.y / spawnedObject.transform.localScale.z);
                spawnedObject.transform.localScale = new Vector3(imageScale.x, spawnedObject.transform.localScale.y, imageScale.y);
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
*/
