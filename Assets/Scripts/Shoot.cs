using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0.2f;
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
        if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
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
