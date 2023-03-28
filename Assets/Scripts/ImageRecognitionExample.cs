using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR;


public class ImageRecognitionExample : MonoBehaviour
{
   
private ARTrackedImageManager _aRTrackedImageManager; // Reference au s c r i p t de gestion
private void Awake()
{
    _aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
}
private void OnEnable()
{
    _aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
}
public void OnDisable()
{
        //_aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
        _aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }
// Cette fonction permet de determiner ce qui se passe lorsqu ' une image est detectee
public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
{
    foreach (var trackedImage in args.added)
    {
        Debug.Log(trackedImage.name);
    }
}
}
