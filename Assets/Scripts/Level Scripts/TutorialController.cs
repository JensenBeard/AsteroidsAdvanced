using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameController;
    public GameObject Observer;
    //public GameObject[] triggers;

    public static int triggerCounter = 0;

    [SerializeField] private GameObject[] triggers;

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
            Debug.Log("Progress");
             //Asteroids (Reach score)
                /*
                if (curScore >= maxScore)
                {
                    bool status = true;
                    gameController.GetComponent<GameController>().setObjectiveComplete(status);
                    ObjectivePrompt.SetActive(false);
                    NextLevelPrompt.SetActive(true);
                }*/
        }


    }
}
