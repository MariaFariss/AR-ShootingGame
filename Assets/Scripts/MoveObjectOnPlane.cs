using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MoveObjectOnPlane : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager _arTrackedImageManager; // Reference to the ARTrackedImageManager
    [SerializeField] private float _moveSpeed = 0.1f; // Speed at which the object will move
    private Vector3 _targetPosition; // Target position to move to


    private void OnEnable() //  Register for the tracked images changed event
    {
        _arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                _targetPosition = trackedImage.transform.position;
                _targetPosition.y = transform.position.y; // Maintain the current y position
            }
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }
}
