using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject fireballPrefab;
    [SerializeField] private AudioClip _audioClip;
    private int rapidAmmoCount;
    private int spreadAmmoCount;

    [SerializeField] private Text ammoCount;
    [SerializeField] private Text weaponType;

    _Shoot _shoot = new _Shoot();

    //Initialises Values
    void Start()
    {
        _shoot.UpdateState(new DefaultShot(this));
        rapidAmmoCount = 100;
        spreadAmmoCount = 50;
    }

    //Updates current state
    void Update()
    {
        _shoot.Update();
    }

    //Changes state when requested
    public void changeState(IShootState newState) 
    {
        _shoot.UpdateState(newState);
    }

    //Fires the basic shot - no limit
    void Fire()
    {
        GameObject fireballClone = Instantiate(fireballPrefab, firingPoint.position, transform.rotation);
        fireballClone.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
        AudioManager.Instance.Play(_audioClip, transform);
    }

    //Fires the rapid shot - has max ammo count
    void FireRapid()
    {
        if (rapidAmmoCount > 0)
        {
            GameObject fireballClone = Instantiate(fireballPrefab, firingPoint.position, transform.rotation);
            fireballClone.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
            AudioManager.Instance.Play(_audioClip, transform);
            rapidAmmoCount -= 1;
        }
        else {
            Debug.Log("Out Of Rapid Ammo");
        }
    }

    //fires the spread shot - has max ammo count
    void FireSpread()
    {
        if (spreadAmmoCount > 0)
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

            AudioManager.Instance.Play(_audioClip, transform);
            spreadAmmoCount -= 1;
        }
        else {
            Debug.Log("Out Of Spread Ammo");
        }
        
    }

    //Updates UI to relevent weapon and ammo aount.

    void updateWeaponSpread() 
    {
        weaponType.text = "WEAPON TYPE: SPREAD";
        ammoCount.text = "AMMO COUNT: " + spreadAmmoCount;
    }

    void updateWeaponRapid()
    {
        weaponType.text = "WEAPON TYPE: RAPID FIRE";
        ammoCount.text = "AMMO COUNT: " + rapidAmmoCount;
    }

    void updateWeaponDefault()
    {
        weaponType.text = "WEAPON TYPE: DEFAULT";
        ammoCount.text = "AMMO COUNT: ∞";
    }
}
