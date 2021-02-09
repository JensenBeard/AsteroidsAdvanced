using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score;
    public int lives;

    public Text scoreText;

    void Start()
    {
        score = 0;

        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScorePoints(int points) 
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
