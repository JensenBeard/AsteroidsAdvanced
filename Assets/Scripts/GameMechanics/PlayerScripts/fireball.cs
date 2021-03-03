using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    private float lifespan = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
        KillOldFireball(lifespan);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.0f);
    }

    void KillOldFireball(float lifeSpan) 
    {
        Destroy(gameObject, lifeSpan);
    }

}
   
