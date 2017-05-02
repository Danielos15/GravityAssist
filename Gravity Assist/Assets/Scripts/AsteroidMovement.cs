using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

	Rigidbody2D rb;
	public float torque;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = transform.forward * torque;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);  // for some simple rotation


		/*float rotation = Input.GetAxis ("Horizontal");
		float acceleration = Input.GetAxis ("Vertical");

		rb.AddTorque (0, rotation * acceleration, 0);
		rb.AddForce (transform.forward * acceleration * torque);*/
	}

	void FixedUpdate() {
		/*float turn = Input.GetAxis("Horizontal");
		rb.AddTorque (torque);*/
	}
}
