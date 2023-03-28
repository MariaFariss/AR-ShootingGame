using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Reference to the projectile prefab to shoot
    [SerializeField] private Transform firePoint; // Reference to the point where the projectile will be spawned
    [SerializeField] private GameObject targetObject; // Reference to the game object to shoot at

    [SerializeField] private float shootForce = 10f; // Force to apply to the projectile when shooting
    [SerializeField] private float timeBetweenShots = 0.5f; // Time between each shot

    private float timeSinceLastShot; // Time elapsed since the last shot
    private Animation aRobot;
    private Animation aGhoul;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime; // Increment time since last shot

        if (timeSinceLastShot >= timeBetweenShots) // Check if enough time has passed since the last shot
        {
            Shoot(); // Shoot at the target object
        }
    }

    void Shoot()
    {
        Vector3 direction = targetObject.transform.position - firePoint.position; // Calculate direction to shoot at the target object
        direction.Normalize(); // Normalize direction to get a unit vector

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity); // Spawn the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>(); // Get the rigidbody component of the projectile

        rb.AddForce(direction * shootForce, ForceMode.Impulse); // Apply force to the projectile in the direction of the target object

        timeSinceLastShot = 0f; // Reset time since last shot
    }
}
