using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPool : MonoBehaviour
{
    [SerializeField] private fireball fireballPrefab;

    private Queue<fireball> fireballs = new Queue<fireball>();
    public static FireballPool Instance { get; private set; }

    //Basic singleton implementation
    private void Awake()
    {
        Instance = this;
    }

    //pre instantiates 50 fireballs
    private void OnEnable()
    {
        AddFireball(50);
    }

    //Retrieve fireball and add more fireballs if needed
    public fireball Get() 
    {
        if (fireballs.Count == 0) 
        {
            AddFireball(1);
        }

        return fireballs.Dequeue();
    }

    //Add more fireballs
    private void AddFireball(int count) 
    {
        for (int i = 0; i < count; i++) 
        {
            fireball fireball = Instantiate(fireballPrefab);
            fireball.gameObject.SetActive(false);
            fireballs.Enqueue(fireball);
        }
    }

    //Return object to pool.
    public void ReturnToPool(fireball fireball) 
    {
        fireball.gameObject.SetActive(false);
        fireballs.Enqueue(fireball);
    }

}
