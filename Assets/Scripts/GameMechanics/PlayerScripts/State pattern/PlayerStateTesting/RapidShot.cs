using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidShot : IShootState
{
    ShootScript owner;
    public RapidShot(ShootScript owner) { this.owner = owner; }
    public void Enter()
    {
        Debug.Log("Enter Test State");

    }

    public void Tick()
    {
        Debug.Log("Update Test State");
    }

    public void Exit()
    {
        Debug.Log("Exit Test State");

    }

}
