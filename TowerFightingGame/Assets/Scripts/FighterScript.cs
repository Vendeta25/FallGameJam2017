﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour {
    Rigidbody2D rb;
    float vertical;

    bool jmpKey;
    float jmpForce;
    float jmpDuration;
    public float jumpForce = .1f;
    public float jumpDuration = .1f;
    bool onFloor;
	// Use this for initialization
	void Start () {


        rb = GetComponent<Rigidbody2D>();
       
    }

    void FixedUpdate()
    {

        
        if (Input.GetButtonDown("Jump") && onFloor )
        {
            jmpDuration = 0;
            jmpForce = 0;
            jmpDuration += Time.deltaTime;
            jmpForce += Time.deltaTime * jumpForce;
            if (jmpDuration < jumpDuration)
            {
           // Debug.Log("Jump jmpForce Report: " +  jmpForce);
                rb.velocity = new Vector2(rb.velocity.x, jmpForce);
                onFloor = false;
            }


        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 30.0f;
        

        
        transform.Translate(x, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Floor")
        {
            onFloor = true;
        }
    }
}
