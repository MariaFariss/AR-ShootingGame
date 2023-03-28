using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARMouvement : MonoBehaviour
{
    [SerializeField] private ARRaycastManager arRaycastManager; // AR raycast manager reference
    [SerializeField] private GameObject player; // Player game object reference
    [SerializeField] private GameObject destination; // Destination game object reference

    private Vector3 destinationPosition; // Destination position in world space
    private bool canMove = false; // Flag to check if player can move

    void Update()
    {
        if (Input.touchCount == 1) // Check if there is only one finger on the screen
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) // Check if the touch began
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                arRaycastManager.Raycast(touch.position, hits, TrackableType.Planes); // Raycast to detect planes

                if (hits.Count > 0)
                {
                    destinationPosition = hits[0].pose.position; // Set the destination position
                    destination.SetActive(true); // Show the destination game object
                    destination.transform.position = destinationPosition; // Move the destination game object to the destination position
                    canMove = true; // Set the canMove flag to true
                }
            }
        }

        if (canMove) // Check if the player can move
        {
            Vector3 direction = (destinationPosition - player.transform.position).normalized; // Calculate the direction towards the destination
            float distance = Vector3.Distance(player.transform.position, destinationPosition); // Calculate the distance to the destination

            if (distance > 0.1f) // Check if the player is not already at the destination
            {
                player.transform.Translate(direction * Time.deltaTime * 3f); // Move the player towards the destination
            }
            else
            {
                canMove = false; // Set the canMove flag to false
                destination.SetActive(false); // Hide the destination game object
            }
        }
    }
}
