using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour {

	private Color color;
	private MeshRenderer mr;
	public Color test;

	// Use this for initialization
	void Start () {
		Gravity planetGravity = GetComponentInParent<Gravity> ();
		float planetMass = GetComponentInParent<Rigidbody2D> ().mass;
		Debug.Log (planetMass);
		color = new Color (0.5490196f, 0.627451f, 0.01960784f, planetGravity.range * 0.02f);
		Debug.Log ("Red " + test.r);
		Debug.Log ("Green " + test.g);
		Debug.Log ("Blue " + test.b);
		Debug.Log ("Alpha " + test.a);
		mr = GetComponent<MeshRenderer> ();
	
	}

	void Update() {
		mr.material.SetColor ("_TintColor", color);
	}
}
