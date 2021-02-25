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

    [SerializeField] private float leftMax = 21f;
    [SerializeField] private float leftMin = 19F;
    [SerializeField] private float topMax = 12f;
    [SerializeField] private float topMin = 11f;
    [SerializeField] private float rightMax = -21f;
    [SerializeField] private float rightMin = -19F;
    [SerializeField] private float botMax = -12f;
    [SerializeField] private float botMin = -11f;

    void Start()
    {
        score = 0;
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
            Instantiate(AsteroidLarge, new Vector3(location[0], location[1], 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }
    }

    float[] SafeSpawnAsteroids() 
    {

        float height;
        float width;

        int key = Random.Range(0, 1);
        //Spawning top/bottom(1) or right/left(0)
        if (key == 1)
        {
            //determine if spawning on top or bottom
            // 1 = top
            key = Random.Range(0, 1);
            if (key == 1)
            {
                width = Random.Range(-18.0f, 18.0f);
                height = Random.Range(topMin, topMax);

            }
            else
            {
                width = Random.Range(-18.0f, 18.0f);
                height = Random.Range(botMin, botMax);

            }
        }
        else 
        {
            key = Random.Range(0, 1);
            if (key == 1)
            {
                height = Random.Range(-12.0f, 12.0f);
                width = Random.Range(leftMin, leftMax);

            }
            else
            {
                height = Random.Range(-12.0f, 12.0f);
                width = Random.Range(rightMin, rightMax);

            }
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
