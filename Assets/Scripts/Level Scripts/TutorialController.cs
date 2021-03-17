using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject gameController;
    public GameObject Observer;

    public int playerHealth;
    public int playerScore;
    float waitTime = 2f;

    public static int triggerCounter = 0;

    [SerializeField] private GameObject[] triggers;
    public GameObject NextLevelPrompt;

    private int maxScore;
    private int progress;

    [SerializeField] private Text ObjectivePrompt;
    [SerializeField] private GameObject introObject;
    [SerializeField] private int numAsteroids;

    private void Start()
    {
       
        gameController.GetComponent<GameController>().setAsteroidNumber(numAsteroids);
        maxScore = 85 * numAsteroids;
        progress = 0;
        Debug.Log("This is running");

    }
    // Update is called once per frame
    private void Update()
    {

        if (progress == 0)
        {//intro
            Invoke("activateTriggers", 5);
            
            progress++;
        }
        else if (progress == 1)
        {//Collect 3 objects
            
            if (triggerCounter == 3)
            {
                progress++;
            }

        }
        else if (progress == 2)
        {

            //Asteroids (Reach score)
            if (waitTime <= 0)
            {
                PlayerPrefs.SetInt("PlayerHealth", playerHealth);
                PlayerPrefs.SetInt("PlayerScore", playerScore);
                gameController.SetActive(true);
                ObjectivePrompt.text = "Objective: Press SPACE to fire photons to destroy all Asteroids!";
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
        }

        int curScore = gameController.GetComponent<GameController>().getScore();
        if (curScore >= maxScore)
        {
            bool status = true;
            PlayerPrefs.SetInt("PlayerScore", curScore);
            gameController.GetComponent<GameController>().setObjectiveComplete(status);
            ObjectivePrompt.text = "Objective: Follow the Arrow to your next destination";
            NextLevelPrompt.SetActive(true);
        }
    }


    private void activateTriggers()
    {
        introObject.SetActive(false);
        ObjectivePrompt.gameObject.SetActive(true);
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].SetActive(true);
        }
        Observer.SetActive(true);
    }
}
