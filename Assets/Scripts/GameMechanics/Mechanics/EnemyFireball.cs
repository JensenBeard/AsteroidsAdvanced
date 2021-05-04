using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    private float lifespan = 3f;
    public GameObject controller;

    //Same code as the pre pooled player fireballs
    //Assign components and set lifespan
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
        KillOldFireball(lifespan);
        controller = GameObject.Find("GameController");
    }

    //Destroy on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.0f);

    }

    //Destroy fireball after delay
    void KillOldFireball(float lifeSpan)
    {
        Destroy(gameObject, lifeSpan);
    }

    //Damage player on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int damage = 20;
            controller.SendMessage("playerDamage", damage);
        }
    }
}