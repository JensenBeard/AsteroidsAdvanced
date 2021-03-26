using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : IShootState
{

    ShootScript owner;
    public SpreadShot(ShootScript owner) { this.owner = owner; }
    public void Enter()
    {
        Debug.Log("Enter Test State");

    }

    public void Tick()
    {
        Debug.Log("Update Test State 2");
    }

    public void Exit()
    {
        Debug.Log("Exit Test State");

    }
}
