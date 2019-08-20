﻿using UnityEngine;
using System.Collections;

public class MPPlayerMovement : MonoBehaviour {

	CharacterController charController;

	[SerializeField] float jumpSpeed = 20.0f;
	[SerializeField] float gravity = 1.0f;
	float yVelocity = 0.0f;

	[SerializeField] float moveSpeed = 5.0f;
	public float h;
    public float v;
    Animator anim;
    public int player;

	// Use this for initialization
	void Start () {
		charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal"+player);
		v = Input.GetAxis ("Vertical"+player);
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
	
		Vector3 direction = new	 Vector3(h, 0, v);
		Vector3 velocity = direction * moveSpeed;
		if (charController.isGrounded) {
			if(Input.GetButtonDown("Jump"))
			{
                anim.SetTrigger("Jump");
				yVelocity = jumpSpeed;
			}

		} else {
			yVelocity -= gravity;
		}
		velocity.y = yVelocity;

		velocity = transform.TransformDirection (velocity);

		charController.Move(velocity*Time.deltaTime);	

	}
}
