using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceIndicator : MonoBehaviour {

	private bool insideView;
	private Transform trans;
	private Camera camera;
	private float distanceFromEdge;
	private Transform parentTrans;

	// Use this for initialization
	void Start () {
		parentTrans = GetComponentInParent<Transform> ();
		camera = Camera.main;
		trans = GetComponent<Transform> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log (camera.ScreenToWorldPoint(parentTrans.position));
		if (!insideView) {
			Debug.Log (camera.WorldToScreenPoint (parentTrans.position));
		}
	}
		
	void OnBecameInvisible() {
		insideView = false;
	}

	void OnBecameVisible() {
		insideView = true;
	}
}
