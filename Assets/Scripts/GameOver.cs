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
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SpaceTheFinalFronteer");
        Time.timeScale = 1;
    }

}
