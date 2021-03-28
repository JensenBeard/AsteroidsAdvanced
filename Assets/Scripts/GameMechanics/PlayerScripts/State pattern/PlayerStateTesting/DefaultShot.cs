using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShot : IShootState
{
    ShootScript owner;
    public float fireRate = 0.3f;
    float timeUntilFire;
    public DefaultShot(ShootScript owner) 
    { 
        this.owner = owner;
    }
    public void Enter()
    {
        Debug.Log("Enter Test State");
        return;
    }

    public void Tick()
    {
        if (Input.GetKeyDown("q"))
        {
            owner.changeState(new SpreadShot(owner));
        }
        if (Input.GetKeyDown("space") && timeUntilFire < Time.time)
        {
            owner.SendMessage("Fire");
            timeUntilFire = Time.time + fireRate;
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Test State");
        return;
    }
}
