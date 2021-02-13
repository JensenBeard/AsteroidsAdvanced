using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float maxThrust = 10f;
    public float maxTorque = 3f;
    public Rigidbody2D rb;
    private Camera mainCam;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    public int asteroidStage; //3 = large 2 = med 1 = small
    public GameObject asteroidsMedium;
    public GameObject asteroidsSmall;

    private int damage = 0;
    public int points;
    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");

        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    // Update is called once per frame
    void Update()
    {
        checkPosition();
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
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
            controller.SendMessage("ScorePoints", points);

            Destroy(gameObject);

        }
        
    }

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
