using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    private float lifespan = 3f;
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
        KillOldFireball(lifespan);
        controller = GameObject.Find("GameController");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.0f);
        
    }

    void KillOldFireball(float lifeSpan)
    {
        Destroy(gameObject, lifeSpan);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int damage = 20;
            controller.SendMessage("playerDamage", damage);
        }
    }
}
   
