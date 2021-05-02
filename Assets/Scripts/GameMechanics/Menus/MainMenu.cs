﻿using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void playButtonClick()
    {
        AudioManager.Instance.Play(_audioClip, transform);
    }
}
