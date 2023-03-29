using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GhoulScript : MonoBehaviour
{
    private Animation animations;
    private int score = 0;
    public Text scoreText;

    //public GameObject shoot;

    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        //shoot.SetActive(false);

    }

    void Update()
    {
        killObject(gameObject);
        scoreText.text = "Score: " + score;
        
    }
    void killObject(GameObject gameObject) //Fonction qui permet de tuer un objet
    {
        // V�rification si l'utilisateur touche l'�cran
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // Rayon depuis la cam�ra vers le point de touch�
            RaycastHit hit; // Informations sur l'objet touch�

            // D�tection de l'objet touch�
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    animations.Play("Death");
                    score++;
                    //shoot.SetActive(true);
                }
            }
            
        }

        shutDownAnnimation();
    }

    void shutDownAnnimation() // Fonction qui permet de d�sactiver l'animation de mort
    {
        if (animations.isPlaying && animations["Death"].time >= animations["Death"].length)
        {
            animations.Stop();

            // G�n�ration d'une position al�atoire pour le nouveau Ghoul
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
