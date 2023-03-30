using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ghoul")
        {
            Destroy(collision.transform.gameObject); // destroy the ghoul
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        }
    }
}


