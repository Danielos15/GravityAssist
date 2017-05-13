using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour {

	public GameObject launchInstructions;
	public GameObject gravityInstructions;
	public GameObject endGate;

	public Color start;
	Color end;
	float duration = 8;
	float t = 0.005f;

	// Use this for initialization
	void Start () {
		end.r = 255;
		end.g = 0;
		end.b = 0;
		end.a = 0;

		if (GameOptions.getInstance ().getHasPlayed()) {
			Destroy (gameObject);
		} else {
			GameOptions.getInstance ().setHasPlayed (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		ChangeColor ();
	}

	void ChangeColor() {
			launchInstructions.GetComponent<TextMesh> ().color = Color.Lerp (start, end, t);
			gravityInstructions.GetComponent<TextMesh> ().color = Color.Lerp (start, end, t);
			endGate.GetComponent<TextMesh> ().color = Color.Lerp (start, end, t);
			if (t < 1) {
				t += Time.deltaTime / duration;
			}
	}
}
