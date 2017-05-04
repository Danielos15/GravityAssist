using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBoundsCheck : MonoBehaviour {
	
	void OnTrigger2DExit(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Left the game area");
		}
	}
}
