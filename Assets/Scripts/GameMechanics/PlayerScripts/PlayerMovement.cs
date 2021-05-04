﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;
public class PlayerMovement : MonoBehaviour
{
    private float thrust = 6f;
    private float rotationSpeed = -180f;
    private float maxSpeed = 4.5f;
    public Animator animator;
    [SerializeField] private AudioClip _audioClip;

    private Camera mainCam;

    private Rigidbody2D rb;

    [HideInInspector] public bool isFacingRight = true;

    //Assign vars and set spawnpoint
    private void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        playerSpawnLocation();
    }

    //Activates animation on keypress
    private void Update()
    {
        enableTrail();
    }

    //Player movement on keypress
    private void FixedUpdate()
    {
        ControlRocket();
        CheckPosition();
        
    }

    //Sets player spawn location dependant on entrance direction.
    void playerSpawnLocation()
    {
        int direction = PlayerPrefs.GetInt("EntranceDir");
        switch (direction) {
            case 0:
                transform.position = new Vector2(0, -9);
                Debug.Log(direction + " 0");
                break;
            case 1:
                transform.position = new Vector2(-17, 0);
                transform.Rotate(new Vector3(0,0,270));
                Debug.Log(direction + " 1");
                break;
            case 2:
                transform.position = new Vector2(0, 9);
                transform.Rotate(new Vector3(0, 0, 180));
                Debug.Log(direction + " 2");
                break;
            case 3:
                transform.position = new Vector2(17, 0);
                transform.Rotate(new Vector3(0, 0, 90));
                Debug.Log(direction + " 3");
                break;
            default:
                transform.position = new Vector2(0, 0);
                Debug.Log(direction + " default");
                break;
        }
        
    }

    //adds momentum and rotation on given inputs
    private void ControlRocket() 
    {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        rb.AddForce(transform.up * thrust * Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));
        
    }

    //Checks to see if player goes off screen and positions accordingly
    private void CheckPosition()
    {
        float sceneWidth = mainCam.orthographicSize * 2 * mainCam.aspect;
        float sceneHeight = mainCam.orthographicSize * 2;

        float sceneRightEdge = sceneWidth / 2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        if (transform.position.x > sceneRightEdge) 
        {
            transform.position = new Vector2(sceneLeftEdge, transform.position.y);
        }
        if (transform.position.x < sceneLeftEdge)
        {
            transform.position = new Vector2(sceneRightEdge, transform.position.y);
        }
        if (transform.position.y > sceneTopEdge)
        {
            transform.position = new Vector2(transform.position.x, sceneBottomEdge);
        }
        if (transform.position.y < sceneBottomEdge)
        {
            transform.position = new Vector2(transform.position.x, sceneTopEdge);
        }


    }

    //Resets spawn location to 0,0,0
    public void ResetShip()
    {
        transform.position = new Vector2(0f, 0f);
        transform.eulerAngles = new Vector3(0, 0f, 0);
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = 0;
    }

    //Plays trail animation
    void enableTrail() 
    {
        if (Input.GetKey("w"))
        {
            
            animator.SetBool("IsForward",true);
            AudioManager.Instance.Play(_audioClip, transform, 0.2f);
        }
        else 
        {
            animator.SetBool("IsForward", false); ;
        }
    }

    //freezes movement on intersection with level trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Trigger")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
        }
    }
}
