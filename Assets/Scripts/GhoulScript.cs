using System.Collections;
using UnityEngine;

public class GhoulScript : MonoBehaviour
{
    private Animation animations;

    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        
    }

    void Update()
    {
        killObject(gameObject);
    }
    void killObject(GameObject gameObject) //Fonction qui permet de tuer un objet
    {
        // Vérification si l'utilisateur touche l'écran
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // Rayon depuis la caméra vers le point de touché
            RaycastHit hit; // Informations sur l'objet touché

            // Détection de l'objet touché
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    animations.Play("Death");
                    

                }
            }
            
        }

        shutDownAnnimation();
    }

    void shutDownAnnimation() // Fonction qui permet de désactiver l'animation de mort
    {
        if (animations.isPlaying && animations["Death"].time >= animations["Death"].length)
        {
            animations.Stop();

            // Génération d'une position aléatoire pour le nouveau Ghoul
            float randomX = UnityEngine.Random.Range(-1f, 1f);
            float randomY = UnityEngine.Random.Range(-1f, 1f);
            float randomZ = UnityEngine.Random.Range(-1f, 1f);
            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);
            
            Instantiate(gameObject, randomPosition, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter(Collider other) // Function helps to destroy the bullet when it hits the Ghoul (for the moment it does not work)
    {
        if (other.gameObject.tag == "bullet")
        {
            animations.Play("Death");
            Destroy(other.gameObject);
        }
    }
}
