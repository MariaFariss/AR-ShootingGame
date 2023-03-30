using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;
    public GameObject enemyToSpawn;
    Vector3 killPos;
    Quaternion killRot;
    public float waitTime = 3.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ghoul")
        {
            Destroy(collision.transform.gameObject); // destroy the ghoul
            killPos = collision.transform.position;
            killRot = collision.transform.rotation;
            StartCoroutine(SpawnEnemyAgain());
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        }
    }
    IEnumerator SpawnEnemyAgain()
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(enemyToSpawn, killPos, killRot);

    }
}


