using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float fireRate = 0.1f;
    public float rapidFireRate = 0.01f;
    public Transform firingPoint;
    public GameObject fireballPrefab;
    float timeUntilFire;



    _Shoot _shoot = new _Shoot();
    void Start()
    {
        _shoot.UpdateState(new DefaultShot(this));
    }

    // Update is called once per frame
    void Update()
    {
        _shoot.Update();
    }


    public void changeState(IShootState newState) 
    {
        _shoot.UpdateState(newState);
    }




    void Fire()
    {
        GameObject fireballClone = Instantiate(fireballPrefab, firingPoint.position, transform.rotation);
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
}
