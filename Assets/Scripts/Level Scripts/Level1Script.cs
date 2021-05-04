using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
    public GameObject gameController;
    public GameObject ObjectivePrompt;
    public GameObject NextLevelPrompt;
    private int maxScore;
    [SerializeField] private int numAsteroids;

    //All Level Scripts follow the same format
    private void Start()
    {
        //Setting number of asteroids, and establishing threshhold score
        gameController.GetComponent<GameController>().setAsteroidNumber(numAsteroids);
        maxScore = PlayerPrefs.GetInt("PlayerScore") + (85*numAsteroids);

        //Starting Gameplay
        gameController.SetActive(true);
        ObjectivePrompt.SetActive(true);
    }

    void Update()
    {
        //Checks if the player has reached the threshhold score
        int curScore = gameController.GetComponent<GameController>().getScore();
        if (curScore >= maxScore) 
        {
            bool status = true;
            //activates the level triggers.
            gameController.GetComponent<GameController>().setObjectiveComplete(status);
            ObjectivePrompt.SetActive(false);
            NextLevelPrompt.SetActive(true);
        }
    }
}
