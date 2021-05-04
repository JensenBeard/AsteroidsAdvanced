using System.IO;
using UnityEngine;


public class Highscores : MonoBehaviour
{
    [SerializeField] private Transform highscoresContainerTransform;
    [SerializeField] private GameObject highscoreEntryTemplate; 
     
    //Loads highscores from file and updates UI
    private void Start()
    {
        HighscoreSaveData savedScores = HighScoreWriter.GetSavedScores();
        UpdateUI(savedScores);
    }

    //Loads highscores from file and updates UI
    private void OnEnable()
    {
        HighscoreSaveData savedScores = HighScoreWriter.GetSavedScores();

        UpdateUI(savedScores);
    }

    //Updates UI, creating new entrys if needed
    private void UpdateUI(HighscoreSaveData savedScores) 
    {
        foreach (Transform child in highscoresContainerTransform) 
        {
            Destroy(child.gameObject);
        }

        foreach (HighscoreEntry highscore in savedScores.highscoreList) 
        {
            Instantiate(highscoreEntryTemplate, highscoresContainerTransform).GetComponent<HighscoreUI>().Initalise(highscore);
        }
    }

    
}



