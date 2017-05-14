using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorelist : MonoBehaviour {

	public GameObject scorePrefab;

	// Use this for initialization
	void Start () {
		// TODO Add loading symbol
	}

	public int setScore(Score[] scores) {
		int pos = 0;
		foreach(Score score in scores) {
			pos += 1;
			GameObject test = Instantiate (scorePrefab);
			test.transform.FindChild ("Place").GetComponent<Text> ().text = pos.ToString();
			test.transform.FindChild ("Username").GetComponent<Text> ().text = score.user_name;
			test.transform.FindChild ("Score").GetComponent<Text> ().text = score.score.ToString();

			test.transform.SetParent (this.transform);
		}
		Destroy (GameObject.FindGameObjectWithTag ("LoadingIcon"));
		return pos;
	}
}
