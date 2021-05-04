using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject controller;
    [SerializeField] private int damage;
    [SerializeField] int points = 50;

    private int health = 50;
    public Transform player;
    public GameObject bullet;
    public float bulletSpeed;
    public float shootingDelay; //seconds
    private float lastShot = 0;

    //Sets Params and rotation (to make animation look better)
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        controller = GameObject.FindWithTag("GameController");
        transform.Rotate(0, 0, 2 * rotationSpeed * Time.deltaTime);
    }

    //AI will constatnly shoot at the player until dead
    void Update()
    {
        if (Time.time > lastShot + shootingDelay) 
        {
            //Shoot
            AIShooting();
            lastShot = Time.time;
        }        
    }

    //Ai will move slowly towards the player
    private void FixedUpdate()
    {
        direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);


    }

    //Instantiates new bullet and fires at player.
    private void AIShooting() 
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        //Make bullet
        GameObject newBullet = Instantiate(bullet, transform.position, q);

        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletSpeed));

    }

    //Takes damage when player shoots it.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= damage;
            Debug.Log(health);
            if (health <= 0)
            {
                //Check Asteroid Size and spawn next size
                controller.SendMessage("ScorePoints", points);
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }

    }
}
