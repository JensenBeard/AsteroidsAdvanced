using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameCreation : MonoBehaviour
{
    public Text Username_field;
    
    //Sets entered username to Username playerpref
    public void setUsername() 
    {
        string userID = Username_field.text.ToString();
        if (userID == "") {
            userID = "___";
        }
        PlayerPrefs.SetString("Username", userID);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("Username"));
    }
}
