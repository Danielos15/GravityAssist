using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	GameController gameManager;
	private Transform trans;
	private Rigidbody2D rigid;
	private CapsuleCollider2D shipCollider;
	public float finishDelay;

	// Use this for initialization
	void Start () {
		shipCollider = GetComponent<CapsuleCollider2D> ();
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
			if (finishDelay > 0.0f) {
				finishDelay -= Time.deltaTime;
				rigid.velocity = Vector2.zero;
				trans.position = Vector2.Lerp (trans.position, other.GetComponent<Transform> ().position, 0.1f);
				trans.Rotate (trans.forward * 240 * Time.deltaTime);
				trans.localScale = Vector3.Lerp (trans.localScale, new Vector3 (0.01f, 0.01f, 0.01f), 0.05f);
			} else {
				Debug.Log ("Level Done!"); // TODO: Show score screen
				shipCollider.isTrigger = false;
			}
		}
	}
}
