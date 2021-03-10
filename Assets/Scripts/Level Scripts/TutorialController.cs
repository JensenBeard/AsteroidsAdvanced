﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameController;
    public GameObject Observer;
    

    public static int triggerCounter = 0;

    [SerializeField] private GameObject[] triggers;
    public GameObject ObjectivePrompt;
    public GameObject NextLevelPrompt;

    private int maxScore = 5 * 3 + 2 * 10 * 3 + 4 * 15 * 3;
    private float waitTime = 2f;
    private int progress;
    private void Start()
    {
        gameController.GetComponent<GameController>().setAsteroidNumber(3);
        progress = 0;
        Debug.Log("This is running");

    }
    // Update is called once per frame
    private void Update()
    {

        if (progress == 0)
        {//intro
            progress++;
            for (int i = 0; i < triggers.Length; i++) 
            {
                triggers[i].SetActive(true);
            }
            Observer.SetActive(true);
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
                gameController.SetActive(true);
                //ObjectivePrompt.GetComponent<TextMeshPro>().SetText("Press SPACE to fire photons to destroy all Asteroids!");
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
            gameController.GetComponent<GameController>().setObjectiveComplete(status);
            //ObjectivePrompt.GetComponent<TextMeshPro>().SetText("");
            NextLevelPrompt.SetActive(true);
        }
    }
}
