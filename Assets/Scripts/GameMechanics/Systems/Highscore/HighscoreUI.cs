﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] private Text entryNameText;
    [SerializeField] private Text entryScoreText;

    //Updates save data to UI
    public void Initalise(HighscoreEntry highscoreEntry) 
    {
        entryNameText.text = highscoreEntry.entryName;
        entryScoreText.text = highscoreEntry.entryScore.ToString();
    }
}



