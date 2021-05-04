using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionReplay : MonoBehaviour
{
    private bool isInReplayMode;
    private int currentReplayIndex;
    private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();
    private Rigidbody2D rb;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //if R is pressed all actions the attached objects have taken are replayed to the player.
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            isInReplayMode = !isInReplayMode;

            if (isInReplayMode) 
            {
                setTransform(0);
                rb.isKinematic = true;

            }
            else 
            {
                setTransform(actionReplayRecords.Count - 1);
                rb.isKinematic = false;
                Time.timeScale = 1;
            }
        }
    }

    //Records postition of object script is attached to.
    private void FixedUpdate()
    {
        if (isInReplayMode == false)
        {
            actionReplayRecords.Add(new ActionReplayRecord { position = transform.position, rotation = transform.rotation });
        }
        else 
        {
            int nextIndex = currentReplayIndex + 1;

            if (nextIndex < actionReplayRecords.Count)
            {
                setTransform(nextIndex);
            }
            else 
            {
                Time.timeScale = 0;
            }

        }
        
    }

    //Replays position from list of recorded postitions.
    private void setTransform(int index) 
    {
        currentReplayIndex = index;
        ActionReplayRecord actionReplayRecord = actionReplayRecords[index];

        transform.position = actionReplayRecord.position;
        transform.rotation = actionReplayRecord.rotation;
    }
}
