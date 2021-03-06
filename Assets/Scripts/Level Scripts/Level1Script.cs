﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{

    public GameObject gameController;
    public GameObject ObjectivePrompt;
    public GameObject[] NextLevelPrompt;
    private int maxScore;
    private void Start()
    {
        gameController.GetComponent<GameController>().setAsteroidNumber(5);
        maxScore = 5 * 5 + 2 * 10 * 3 + 4 * 15 * 5;
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
        }
    }
}
