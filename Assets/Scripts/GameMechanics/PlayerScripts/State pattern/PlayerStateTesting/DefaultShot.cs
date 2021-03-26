using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShot : IShootState
{
    ShootScript owner;
    public float fireRate = 0.1f;
    public Transform firingPoint;
    public GameObject fireballPrefab;
    public DefaultShot(ShootScript owner) 
    { 
        this.owner = owner;
    }
    public void Enter()
    {
        Debug.Log("Enter Test State");

    }

    public void Tick()
    {
        if (Input.GetKeyDown("q"))
        {
            owner.changeState(new SpreadShot(owner));
        }
        Debug.Log("Update Test State");
    }

    public void Exit()
    {
        Debug.Log("Exit Test State");

    }

  
}
