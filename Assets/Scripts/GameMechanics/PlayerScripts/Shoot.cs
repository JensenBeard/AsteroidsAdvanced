using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0.1f;
    public Transform firingPoint;
    public GameObject fireballPrefab;

    float timeUntilFire;
    PlayerMovement pm;

    private void Start()
    {

        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && timeUntilFire < Time.time)
        {
            Fire();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Fire()
    {
       GameObject fireballClone =  Instantiate(fireballPrefab, firingPoint.position, transform.rotation);
       fireballClone.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
       
    }
}
