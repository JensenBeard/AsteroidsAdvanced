using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0.1f;
    public float rapidFireRate = 0.01f;
    public Transform firingPoint;
    public GameObject fireballPrefab;

    private WeaponType _currentState;

    float timeUntilFire;


    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            _currentState = WeaponType.Basic;
            Debug.Log("1");
        }
        else if (Input.GetKeyDown("2")) 
        {
            _currentState = WeaponType.RapidFire;
            Debug.Log("2");
        }
        else if (Input.GetKeyDown("3"))
        {
            _currentState = WeaponType.Spread;
            Debug.Log("3");
        }

        switch (_currentState) 
        {
            case WeaponType.Basic:
                {
                    if (Input.GetKeyDown("space") && timeUntilFire < Time.time)
                    {
                        Fire();
                        timeUntilFire = Time.time + fireRate;
                    }
                    break;
                }
            case WeaponType.RapidFire: 
                {
                    if (Input.GetKey("space") && timeUntilFire < Time.time)
                    {
                        Fire();
                        timeUntilFire = Time.time + rapidFireRate;
                    }
                    break;
                }
            case WeaponType.Spread:
                {
                    if (Input.GetKeyDown("space") && timeUntilFire < Time.time)
                    {
                        FireSpread();
                        timeUntilFire = Time.time + fireRate;
                    }
                    break;
                }
        }
        
    }

    void Fire()
    {
       GameObject fireballClone =  Instantiate(fireballPrefab, firingPoint.position, transform.rotation);
       fireballClone.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
    }

    void FireSpread()
    {
        Quaternion rotation = transform.rotation;

        

        GameObject fireballClone1 = Instantiate(fireballPrefab, firingPoint.position, transform.rotation);
        
        Vector3 cone1 = transform.eulerAngles + new Vector3(0, 0, 30);
        rotation.eulerAngles = cone1;

        GameObject fireballClone2 = Instantiate(fireballPrefab, firingPoint.position, rotation);

        Vector3 cone2 = transform.eulerAngles + new Vector3(0, 0, -30);
        rotation.eulerAngles = cone2;

        GameObject fireballClone3 = Instantiate(fireballPrefab, firingPoint.position, rotation);


        fireballClone1.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);

        fireballClone2.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
        
        fireballClone3.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);

    }

    private enum FireState 
    {
        STATE_IDLE,
        STATE_FIRING
    }

    private enum WeaponType
    { 
        Basic,
        RapidFire,
        Spread
    }
}
