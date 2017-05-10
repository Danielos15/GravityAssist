using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidOrbit : MonoBehaviour {

	public Transform planet;
	public float speed;
	private Transform trans;

	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();	
	}

	// Update is called once per frame
	void Update () {
		trans.RotateAround (planet.position, Vector3.forward, speed);
	}
}
