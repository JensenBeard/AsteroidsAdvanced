﻿using System.Collections;
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
        owner.SendMessage("updateWeaponDefault");
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
            owner.SendMessage("updateWeaponDefault");
            timeUntilFire = Time.time + fireRate;
        }
    }

    public void Exit()
    {
        return;
    }
}

