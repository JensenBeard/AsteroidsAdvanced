using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    private float lifespan = 3f;
    private float lifetime;
    public GameObject controller;

    //Improved pooled version of the fireball script (Used for the player shooting)
    void OnEnable()
    {
        lifetime = 0f;
        GetComponent<Rigidbody2D>().AddForce(transform.up * 700);
        controller = GameObject.Find("GameController");
    }

    //returns to queue instead of destroying 
    void OnCollisionEnter2D(Collision2D collision)
    {
        FireballPool.Instance.ReturnToPool(this);
        
    }

    //if fireball exeeds lifespan return to pool.
    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > lifespan) 
        {
            FireballPool.Instance.ReturnToPool(this);
        }
    }

    //damage player on collision (dont hit yourself!)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int damage = 20;
            controller.SendMessage("playerDamage", damage);
        }
    }
}
   
