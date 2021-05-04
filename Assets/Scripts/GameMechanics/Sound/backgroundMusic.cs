﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

public class backgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    //initalizes bgm loop
    private void Awake()
    {
        AudioManager.Instance.PlayLoop(_audioClip, transform);
    }
}
