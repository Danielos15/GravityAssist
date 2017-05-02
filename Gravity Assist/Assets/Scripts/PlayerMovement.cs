using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Transform trans;
	private Rigidbody2D rigid; 
	public float fuel;
	public float fuelPerSec;
	public float forceForward;
	public float rotateSpeed;
	private GameController gameManager;


	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
		rigid = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Forward") && fuel > 0.0f) {
			if (!gameManager.isStarted ()) {
				gameManager.startGame ();
			}
			rigid.AddForce (transform.up * forceForward * Time.deltaTime);
			fuel -= fuelPerSec * Time.deltaTime;
		}
		if (Input.GetButton ("Horizontal")) {
			trans.Rotate (-trans.forward * rotateSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);
		}
	}
}
