using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IPlayerState currentState = new PlayerIdle();

    void Update()
    {
       // UpdateState(input);
    }

    void UpdateState(Input input)
    {
        IPlayerState newState = currentState.Tick(this, input);

        if (newState != null) 
        {
            currentState.Exit(this);
            currentState = newState;
            newState.Enter(this);
        }
    }
}
