using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	public float range;
	private Transform trans;
	private Rigidbody2D rigid;
	private GameController gameManager;

	// Use this for initialization
	void Start () {		
		trans = GetComponent<Transform> ();
		rigid = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void FixedUpdate() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll (trans.position, range);
		List<Rigidbody2D> rbs = new List<Rigidbody2D> ();

		foreach (Collider2D col in colliders) {
			Rigidbody2D rb = col.attachedRigidbody;
			if (rb != null && rb != this.rigid && !rbs.Contains (rb)) {
				if (col.gameObject.tag == "Player" && gameManager.isStarted ()) {
					rbs.Add (rb);
					Vector2 offset = trans.position - col.transform.position;
					rb.AddForce (offset / offset.sqrMagnitude * this.rigid.mass);
				}
			}
		}
	}

}
