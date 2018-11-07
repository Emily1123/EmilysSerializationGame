﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;

    private Vector3 movement;
    private Rigidbody playerRigidBody;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Move(horizontal, vertical);
    }

    private void Move(float horizontal, float vertical)
    {
        movement = (vertical * transform.forward) + (horizontal * transform.right);
        movement = movement.normalized * Speed * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }
}
