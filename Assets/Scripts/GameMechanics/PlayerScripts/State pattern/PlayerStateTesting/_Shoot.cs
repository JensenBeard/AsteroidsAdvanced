using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Shoot
{
    private IShootState currentState;
    
    public void Update()
    {
        if (currentState != null) currentState.Tick();
    }

    public void UpdateState(IShootState newState)
    {
        if (currentState != null) 
        {
            currentState.Exit();
            
        }
        currentState = newState;
        currentState.Enter();
    }
}

