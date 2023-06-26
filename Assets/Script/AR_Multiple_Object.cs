using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class AR_Multiple_Object : MonoBehaviour
{
    [SerializeField]
    private GameObject[] mPrefabs;

    private Dictionary<string, GameObject> spawnprefab = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;
    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach(GameObject prefab in mPrefabs)
        {
            GameObject nprefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            nprefab.name = prefab.name;
            spawnprefab.Add(prefab.name, nprefab);

        }
    }
    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }
    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnprefab[trackedImage.name].SetActive(false);
        }
    }
    private void UpdateImage (ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnprefab[name];
        prefab.transform.position = position;
        prefab.SetActive(true);

        foreach (GameObject go in spawnprefab.Values)
        {
            if (go.name != name)
            {
                go.SetActive(false);
            }

        }
    }
}
