using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidShot : IShootState
{
    ShootScript owner;
    public float fireRate = 0.05f;
    float timeUntilFire;
    public RapidShot(ShootScript owner) { this.owner = owner; }
    public void Enter()
    {
        Debug.Log("Enter Test State");
        return;
    }

    public void Tick()
    {
        if (Input.GetKeyDown("q"))
        {
            owner.changeState(new DefaultShot(owner));
        }
        if (Input.GetKey("space") && timeUntilFire < Time.time)
        {
            owner.SendMessage("Fire");
            timeUntilFire = Time.time + fireRate;
        }
    }

    public void Exit()
    {
        return;
    }

}
