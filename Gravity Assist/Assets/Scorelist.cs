using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorelist : MonoBehaviour {

	public GameObject scorePrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			GameObject test = Instantiate (scorePrefab);
			test.transform.SetParent (this.transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
