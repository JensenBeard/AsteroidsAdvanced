using System.IO;
using UnityEngine;


public class Highscores : MonoBehaviour
{
    [SerializeField] private Transform highscoresContainerTransform;
    [SerializeField] private GameObject highscoreEntryTemplate; 
     
    private void Start()
    {
           

        HighscoreSaveData savedScores = HighScoreWriter.GetSavedScores();

        UpdateUI(savedScores);
    }

    private void OnEnable()
    {
        HighscoreSaveData savedScores = HighScoreWriter.GetSavedScores();

        UpdateUI(savedScores);
    }

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



