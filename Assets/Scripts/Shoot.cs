//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Shoot : MonoBehaviour
//{

//    public Transform arCamera;
//    public GameObject projectile;

//    public float shootForce = 700.0f;




//    void Update()
//    {
//        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//        {
//            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation) as GameObject;
//            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform arCamera;
    public GameObject projectile;

    public float shootForce = 700.0f;

    public AudioSource audioSource;
    public AudioClip shootingSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Jouer la piste audio
            audioSource.PlayOneShot(shootingSound);

            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
        }
    }
}
