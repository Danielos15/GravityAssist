using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageChange : MonoBehaviour {
	public GameObject image;
	float duration = 8;
	float t = 0.005f;
	Color end;
	public Color start;

	// Use this for initialization
	void Start () {
		end.r = 255;
		end.g = 0;
		end.b = 0;
		end.a = 0;
	}

	// Update is called once per frame
	void Update () {
			image.GetComponent<SpriteRenderer> ().color = Color.Lerp (start, end, t);
			if (t < 1) {
				t += Time.deltaTime / duration;
			}
	}
}
