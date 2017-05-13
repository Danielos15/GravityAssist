using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour {

	public GameObject instructions;
	public Color start;
	Color end;
	float duration = 6;
	float t = 0.005f;
	bool hasPlayed;

	// Use this for initialization
	void Start () {
		end.r = 255;
		end.g = 0;
		end.b = 0;
		end.a = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeColor ();
	}

	void ChangeColor() {
		instructions.GetComponent<TextMesh> ().color = Color.Lerp (start, end, t);
		if (t < 1) {
			t += Time.deltaTime / duration;
		}

	}
}
