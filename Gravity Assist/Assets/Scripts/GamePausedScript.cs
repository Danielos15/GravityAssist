using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedScript : MonoBehaviour {

	public GameObject pauseMenuPanel;
	public GameObject[] astroids;

	void Start() {
		astroids = GameObject.FindGameObjectsWithTag("Astroid");
	}

	public void buttonMenu(Button button) {
		if (button.name == "Pause") {
			pauseMenuPanel.SetActive (true);
			Time.timeScale = 0;

			foreach (GameObject astroid in astroids) {
				astroid.GetComponent<AstroidOrbit> ().enabled = false;
			}

		}

		if (button.name == "Resume") {
			pauseMenuPanel.SetActive (false);
			Time.timeScale = 1;

			foreach (GameObject astroid in astroids) {
				astroid.GetComponent<AstroidOrbit> ().enabled = true;
			}
		}
	}
}
