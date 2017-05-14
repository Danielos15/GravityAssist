using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerErrorText : MonoBehaviour {

	private float countdown;
	private bool done;
	// Use this for initialization
	void Start () {
		countdown = 10f;
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;

		if (countdown <= 0) {
			if (!GetComponent<Text> ().enabled && !done) {
				done = true;
				GetComponent<Text> ().enabled = true;
				Destroy (GameObject.FindGameObjectWithTag ("LoadingIcon"));
			}
		}
	}
}
