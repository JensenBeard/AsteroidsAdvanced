using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    private Vector2 direction;
    public float speed;
    public float rotationSpeed;
    public Transform player;

    public GameObject bullet;
    public float bulletSpeed;
    public float shootingDelay; //seconds
    private float lastShot = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.Rotate(0, 0, 2 * rotationSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (Time.time > lastShot + shootingDelay) 
        {
            //Shoot
            AIShooting();
            lastShot = Time.time;
        }        
    }

    private void FixedUpdate()
    {
        direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);


    }

    private void AIShooting() 
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        //Make bullet
        GameObject newBullet = Instantiate(bullet, transform.position, q);

        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletSpeed));

    }
}
