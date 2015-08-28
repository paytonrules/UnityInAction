﻿using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {
	public float speed = 3.0f;
	public float gravity = -9.8f;

	private CharacterController characterController;
	
	void Start() {
		characterController = GetComponent<CharacterController> ();
	}
	
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		var movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);
		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);

		characterController.Move (movement);
	}
}
