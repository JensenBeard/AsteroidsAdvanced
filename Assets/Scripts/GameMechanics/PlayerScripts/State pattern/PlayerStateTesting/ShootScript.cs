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
        var shot = FireballPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = firingPoint.position;
       
       // shot.GetComponent<Rigidbody2D>().AddForce(transform.up * 500);
        shot.gameObject.SetActive(true);
        AudioManager.Instance.Play(_audioClip, transform);
    }

    //Fires the rapid shot - has max ammo count
    void FireRapid()
    {
        if (rapidAmmoCount > 0)
        {
            var shot = FireballPool.Instance.Get();
            shot.transform.rotation = transform.rotation;
            shot.transform.position = firingPoint.position;

            shot.gameObject.SetActive(true);
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


     

            var shot1 = FireballPool.Instance.Get();
            shot1.transform.rotation = transform.rotation;
            shot1.transform.position = firingPoint.position;

            shot1.gameObject.SetActive(true);

            Vector3 cone1 = transform.eulerAngles + new Vector3(0, 0, 30);
            rotation.eulerAngles = cone1;

            var shot2 = FireballPool.Instance.Get();
            shot2.transform.rotation = rotation;
            shot2.transform.position = firingPoint.position;

            shot2.gameObject.SetActive(true);

            Vector3 cone2 = transform.eulerAngles + new Vector3(0, 0, -30);
            rotation.eulerAngles = cone2;

            var shot3 = FireballPool.Instance.Get();
            shot3.transform.rotation = rotation;
            shot3.transform.position = firingPoint.position;

            shot3.gameObject.SetActive(true);



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
