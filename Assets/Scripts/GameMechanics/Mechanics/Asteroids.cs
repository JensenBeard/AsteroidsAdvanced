﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private float maxThrust = 10f;
    [SerializeField] private float maxTorque = 3f;
    public Rigidbody2D rb;
    private Camera mainCam;
    [SerializeField] private float screenTop;
    [SerializeField] private float screenBottom;
    [SerializeField] private float screenLeft;
    [SerializeField] private float screenRight;

    [SerializeField] private AudioClip _audioClip;
    private Vector3 point = Vector3.zero;
    public int asteroidStage; //3 = large 2 = med 1 = small
    public GameObject asteroidsMedium;
    public GameObject asteroidsSmall;

    private int damage = 0;
    public int points;
    public GameObject controller;

    //Spawns with random direction and velocity
    void OnEnable()
    {
        controller = GameObject.FindWithTag("GameController");

        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    
    void Update()
    {
        checkPosition();
    }
    //Checks if asteroids go off screen and adjusts position accordingly
    private void checkPosition() 
    {
        Vector2 newPos = transform.position;

        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }
        if (transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }

        transform.position = newPos;
    }

    //Will split into smaller asteroid when shot giving points depending on stage.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            //Check Asteroid Size and spawn next size
            if (asteroidStage == 3)
            {
                //Spawn 2 med
                Instantiate(asteroidsMedium, transform.position, transform.rotation);
                Instantiate(asteroidsMedium, transform.position, transform.rotation);

            }
            else if (asteroidStage == 2)
            {
                Instantiate(asteroidsSmall, transform.position, transform.rotation);
                Instantiate(asteroidsSmall, transform.position, transform.rotation);
            }
            else if (asteroidStage == 1)
            {
               
            }
            AudioManager.Instance.Play(_audioClip, point);
            controller.SendMessage("ScorePoints", points);

            Destroy(gameObject);

        }
        
    }

    //Will damage player on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (asteroidStage == 3)
            {
                damage = 10;
            }
            else if (asteroidStage == 2)
            {
                damage = 15;
            }
            else if (asteroidStage == 1)
            {
                damage = 20;
            }
            controller.SendMessage("playerDamage", damage);
        }
    }
}
