using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingIcon : MonoBehaviour {

	private RectTransform rt;
	// Update is called once per frame
	void Start() {
		rt = GetComponent<RectTransform> ();
	}
	void Update () {
		rt.Rotate(new Vector3(0, 0,-4));
	}
}
