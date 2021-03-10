using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : Subject
{
    [SerializeField] private string poiName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        Notify(poiName, NotificationType.AchievementUnlocked);
    }
}
