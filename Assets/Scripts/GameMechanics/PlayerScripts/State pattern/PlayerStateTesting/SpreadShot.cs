﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : IShootState
{

    ShootScript owner;
    public float fireRate = 0.1f;
    float timeUntilFire;
    public SpreadShot(ShootScript owner) { this.owner = owner; }
    public void Enter()
    {
        owner.SendMessage("updateWeaponSpread");
        return;
    }

    public void Tick()
    {
        if (Input.GetKeyDown("q"))
        {
            owner.changeState(new RapidShot(owner));
        }
        if (Input.GetKeyDown("space") && timeUntilFire < Time.time)
        {
            owner.SendMessage("FireSpread");
            owner.SendMessage("updateWeaponSpread");

            timeUntilFire = Time.time + fireRate;
        }
    }

    public void Exit()
    {
        return;
    }
}
