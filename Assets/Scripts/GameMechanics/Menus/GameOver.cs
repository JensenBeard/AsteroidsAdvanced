using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Text pointsText;
    public void Setup(int score) 
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        uploadHighscore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        Debug.Log("Load Menu");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void uploadHighscore()
    {
        int score = PlayerPrefs.GetInt("PlayerScore");
        string name = PlayerPrefs.GetString("Username");

        Debug.Log(name);
        HighscoreEntry newEntry;
        newEntry.entryName = name;
        newEntry.entryScore = score;

        HighScoreWriter.AddEntry(newEntry);
    }



}
