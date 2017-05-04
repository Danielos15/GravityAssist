using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	GameController gameManager;
	private Transform trans;
	private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
		rigid = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Astroids" || other.gameObject.tag == "CelestialObject") {
			Destroy (gameObject);
			//TODO:
			// Explosion, scorescreen
		} else if (other.gameObject.tag == "Finish") {
			gameManager.endGame ();
		}
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Finish") {
			rigid.velocity = Vector2.zero;
			trans.position = Vector2.MoveTowards (trans.position, other.GetComponent<Transform> ().position, 5.0f * Time.deltaTime);
		}
	}
}
