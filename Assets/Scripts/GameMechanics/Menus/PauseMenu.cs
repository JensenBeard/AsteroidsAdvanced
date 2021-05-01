using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        
    }

    public void LoadMenu() {
        Debug.Log("Load Menu");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        uploadHighscore();
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
