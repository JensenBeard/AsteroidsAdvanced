using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSystem : Observer
{
    
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        foreach (var poi in FindObjectsOfType<PointOfInterest>())
        {
            poi.RegisterObserver(this);
        }
    }

    public override void OnNotify(object value, NotificationType notificationType) 
    {
        if (notificationType == NotificationType.TriggerActivated) 
        {
           
            string triggerKey = "trigger-" + value;

            if (PlayerPrefs.GetInt(triggerKey) == 1) 
               return;

            PlayerPrefs.SetInt(triggerKey, 1);
            Debug.Log("Item " + value + " has been collected");

            TutorialController.triggerCounter++;
            
        }

    }
}

public enum NotificationType
{
    TriggerActivated
}
