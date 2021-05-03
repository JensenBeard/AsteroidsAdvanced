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

    [SerializeField] private GameObject helpPrompt;
    [SerializeField] private Text ObjectivePrompt;
    [SerializeField] private GameObject introObject;
    [SerializeField] private int numAsteroids;

    private TutorialProgress CurState;
    private string username;

    private void Start()
    {
        CurState = TutorialProgress.Initialise;
        gameController.GetComponent<GameController>().setAsteroidNumber(numAsteroids);
        maxScore = 85 * numAsteroids;
        Debug.Log("This is running");
        username = PlayerPrefs.GetString("Username");
       
    }
    // Update is called once per frame
    private void Update()
    {
        int curScore = gameController.GetComponent<GameController>().getScore();
        switch (CurState) 
        {
            case TutorialProgress.Initialise://intro
                Invoke("activateTriggers", 5);
                CurState = TutorialProgress.Collection;
                break;
            case TutorialProgress.Collection://Collect 3 objects
                if (triggerCounter == 3)
                {
                    CurState = TutorialProgress.LevelStart;
                }
                break;
            case TutorialProgress.LevelStart://Asteroids (Reach score)
                if (waitTime <= 0)
                {
                    PlayerPrefs.SetInt("PlayerHealth", playerHealth);
                    PlayerPrefs.SetInt("PlayerScore", playerScore );
                    gameController.SetActive(true);
                    ObjectivePrompt.text = "Objective: Press SPACE to fire photons to destroy all Asteroids! Change Weapons using 'Q' to switch to Spread and Rapid Fire";
                   
                    if (curScore >= maxScore)
                    {
                        CurState = TutorialProgress.LevelEnd;
                    }
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                break;
            case TutorialProgress.LevelEnd://Level Over Score reached
                bool status = true;
                PlayerPrefs.SetInt("PlayerScore", curScore);
                PlayerPrefs.SetString("Username", username);
                gameController.GetComponent<GameController>().setObjectiveComplete(status);
                ObjectivePrompt.text = "Objective: Follow the Arrow to your next destination";
                
                NextLevelPrompt.SetActive(true);
                break;
        }

        
    }


    private void activateTriggers()
    {
        introObject.SetActive(false);
        ObjectivePrompt.gameObject.SetActive(true);
        helpPrompt.gameObject.SetActive(true);
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].SetActive(true);
        }
        Observer.SetActive(true);
    }

    
}
enum TutorialProgress
{
    Initialise,
    Collection,
    LevelStart,
    LevelEnd
}