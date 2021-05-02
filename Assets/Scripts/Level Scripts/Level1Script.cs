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
    private void Start()
    {
        gameController.GetComponent<GameController>().setAsteroidNumber(numAsteroids);
        maxScore = PlayerPrefs.GetInt("PlayerScore") + (85*numAsteroids);
        gameController.SetActive(true);
        ObjectivePrompt.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        int curScore = gameController.GetComponent<GameController>().getScore();
        if (curScore >= maxScore) 
        {
            bool status = true;
            gameController.GetComponent<GameController>().setObjectiveComplete(status);
            ObjectivePrompt.SetActive(false);
            NextLevelPrompt.SetActive(true);
        }
    }
}
