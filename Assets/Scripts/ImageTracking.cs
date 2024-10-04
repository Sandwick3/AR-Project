using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager trackedImages;
    public GameObject[] arPrefabs; // Use camelCase for public variables by convention
    private List<GameObject> arObjects = new List<GameObject>();

    void Awake()
    {
        trackedImages = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImages.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImages.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Event Handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Create object based on image tracked
        foreach (var trackedImage in eventArgs.added)
        {
            foreach (var arPrefab in arPrefabs)
            {
                if (trackedImage.referenceImage.name == arPrefab.name)
                {
                    var newPrefab = Instantiate(arPrefab, trackedImage.transform);
                    arObjects.Add(newPrefab);
                    break; // Exit the loop once you find a match
                }
            }
        }

        // Update tracking position and state
        foreach (var trackedImage in eventArgs.updated)
        {
            for (int i = 0; i < arObjects.Count; i++)
            {
                if (arObjects[i].name == trackedImage.referenceImage.name) // Change trackedImage.name to trackedImage.referenceImage.name
                {
                    arObjects[i].SetActive(trackedImage.trackingState == TrackingState.Tracking);
                }
            }
        }
    }
}
