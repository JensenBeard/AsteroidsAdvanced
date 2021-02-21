using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int health;
    [SerializeField] private int waves;
    [SerializeField] private int numAsteroids;

    public GameObject AsteroidLarge;
    public GameObject AsteroidMed;
    public GameObject AsteroidSmall;
    public GameObject playerObject;
    public GameOver GameOverScreen;

    public Text scoreText;
    public Text livesText;

    void Start()
    {
        score = 0;
        numAsteroids = 5;
        health = 100;
        scoreText.text = "Score: " + score;
        livesText.text = "HP: " + health;
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
            float[] location = SafeSpawnAsteroids();
            Debug.Log("Testing = " + i);
            Instantiate(AsteroidLarge, new Vector3(location[0], location[1], 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }
    }

    float[] SafeSpawnAsteroids() 
    {
        float width = Random.Range(-16.0f, 16.0f);
        float height = Random.Range(-8.0f, 8.0f);
        if ((width < 1 && width > -1)&&(height < 1 && height >-1)) {
            SafeSpawnAsteroids();
        }
        float[] location = new float[] { width, height };
        return location;
    }

    public void playerDamage(int damage) 
    {
        health -= damage;
        if (health <= 0) {
            health = 0;
            playerObject.GetComponent<PlayerMovement>().ResetShip();
            Time.timeScale = 0;
            GameOverFun();
        }
        livesText.text = "HP: " + health;

    }

    public void GameOverFun() 
    {
        GameOverScreen.Setup(score);
    }


}
