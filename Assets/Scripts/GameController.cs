using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score;
    public int lives;
    public int numAsteroids;
    public GameObject AsteroidLarge;
    public GameObject AsteroidMed;
    public GameObject AsteroidSmall;

    public Text scoreText;

    void Start()
    {
        score = 0;
        numAsteroids = 5;
        scoreText.text = "Score: " + score;
        SpawnAsteroids();
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
    
    void SpawnAsteroids() 
    {
        for (int i = 0; i < numAsteroids; i++) 
        {
            Instantiate(AsteroidLarge, new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-6.0f, 6.0f), 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }
    }

}
