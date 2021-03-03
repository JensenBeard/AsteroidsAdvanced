using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject gameController;
    private int popUpIndex;
    public GameObject spawner;
    public GameObject ObjectivePrompt;
    public GameObject NextLevelPrompt;
    public float waitTime = 2f;

    [SerializeField] private int maxScore = 425;

    private void Update()
    {
        int curScore = gameController.GetComponent<GameController>().getScore();

        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else {
                popUps[i].SetActive(false);
            }
        }


        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }

        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (waitTime <= 0)
            {
                spawner.SetActive(true);
                popUps[popUpIndex].SetActive(false);
                ObjectivePrompt.SetActive(true);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        } 
        
        
        if (curScore == maxScore)
        {
            bool status = true;
            gameController.GetComponent<GameController>().setObjectiveComplete(status);
            ObjectivePrompt.SetActive(false);
            NextLevelPrompt.SetActive(true);
        }
    }
}
