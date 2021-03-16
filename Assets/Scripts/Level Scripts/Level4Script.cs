using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Script : MonoBehaviour
{
    public GameObject gameController;
    public GameObject ObjectivePrompt;
    public GameObject[] NextLevelPrompt;
    public GameObject EnemyShip;
    private int maxScore;

    [SerializeField] private float leftMax = 21f;
    [SerializeField] private float leftMin = 19F;
    [SerializeField] private float topMax = 12f;
    [SerializeField] private float topMin = 11f;
    [SerializeField] private float rightMax = -21f;
    [SerializeField] private float rightMin = -19F;
    [SerializeField] private float botMax = -12f;
    [SerializeField] private float botMin = -11f;
    [SerializeField] private int numEnemys;

    private void Start()
    {
        gameController.GetComponent<GameController>().setAsteroidNumber(5);
        maxScore = PlayerPrefs.GetInt("PlayerScore") + (5 * 5 + 2 * 10 * 3 + 4 * 15 * 5);
        gameController.SetActive(true);
        ObjectivePrompt.SetActive(true);
        SpawnEnemyShips();
    }
    //Update is called once per frame
    void Update()
    {
        int curScore = gameController.GetComponent<GameController>().getScore();
        
        if (curScore >= maxScore)
        {
            bool status = true;
            gameController.GetComponent<GameController>().setObjectiveComplete(status);
            ObjectivePrompt.SetActive(false);
        }
        //Can maybe spawn some enemy ai at some point
    }

    void SpawnEnemyShips()
    {
        for (int i = 0; i < numEnemys; i++)
        {
            float[] location = SafeSpawnShip();
            Instantiate(EnemyShip, new Vector3(location[0], location[1], 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }
    }

    float[] SafeSpawnShip()
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
}
