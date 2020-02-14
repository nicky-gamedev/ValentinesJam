﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity;
    public float maxVelocity;
    public Transform sensor;
    public LayerMask chao;
    float lado;
    bool estaNoChao;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        #region movimento
        rb.velocity = new Vector2(lado * velocity, rb.velocity.y);
        if (Input.GetButtonDown("Horizontal"))
        {
            lado = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetButton("Horizontal"))
        {
            if (velocity <= maxVelocity)
            {
                velocity++;
            }
        }
        else
        {
            if (velocity >= 0.25f)
            {
                velocity -= 0.25f;
            }
        }
        #endregion movimento

        estaNoChao = Physics2D.OverlapCircle(sensor.position, .3f, chao);
        if(estaNoChao && Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}