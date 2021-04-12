﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameCreation : MonoBehaviour
{
    public Text Username_field;
    
    public void setUsername() 
    {
        string userID = Username_field.text.ToString();
        if (userID == "") {
            userID = "___";
        }
        PlayerPrefs.SetString("Username", userID);
        Debug.Log(PlayerPrefs.GetString("Username"));
    }
}
