using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{

    TextMeshProUGUI scoreText; // c'est le texte qui contient le score
    GameObject scoreBoardUI; // c'est le canva qui contient le score
    public static int score; // c'est le score

    private void Start()
    {
        gameObject.GetComponent<Shoot>().enabled = true; // on active le script de tir
        scoreBoardUI = GameObject.FindGameObjectWithTag("ScoreCanvas"); //  on récupère le canva qui contient le score
        scoreText = GameObject.FindGameObjectWithTag("ScoreOnBanner").GetComponent<TextMeshProUGUI>(); // on récupère le texte qui contient le score
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString(); // on met à jour le score
    }



}


