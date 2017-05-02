using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetaryRotation : MonoBehaviour {
	private Transform trans;

	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		trans.Rotate (trans.forward * 10 * Time.deltaTime);
		trans.Rotate (trans.up * 20 * Time.deltaTime);
	}
}
