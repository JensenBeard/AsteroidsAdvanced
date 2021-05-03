using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPool : MonoBehaviour
{
    [SerializeField] private fireball fireballPrefab;

    private Queue<fireball> fireballs = new Queue<fireball>();
    public static FireballPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        AddFireball(50);
    }

    public fireball Get() 
    {
        if (fireballs.Count == 0) 
        {
            AddFireball(1);
        }

        return fireballs.Dequeue();
    }

    private void AddFireball(int count) 
    {
        for (int i = 0; i < count; i++) 
        {
            fireball fireball = Instantiate(fireballPrefab);
            fireball.gameObject.SetActive(false);
            fireballs.Enqueue(fireball);
        }
    }

    public void ReturnToPool(fireball fireball) 
    {
        fireball.gameObject.SetActive(false);
        fireballs.Enqueue(fireball);
    }

}
