using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : IPlayerState
{

    public void Enter(Player player) 
    {
        return;
    }

    public IPlayerState Tick(Player player, Input input) 
    {
        
        return null;
    }

    public void Exit(Player player) 
    {
    //    Destroy(this);
        return;
    }
   
}
