using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GamePausedScript : MonoBehaviour {

	public GameObject pauseMenuPanel;
	public GameObject[] astroids;
	private GameObject level;
	private GameObject main;
	private MainMenu menu;

	void Start() {
		astroids = GameObject.FindGameObjectsWithTag("Astroid");
		level = menu.GetComponent<MainMenu> ().levelPanel;
		main = menu.GetComponent<MainMenu> ().mainMenuPanel;
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

		if (button.name == "LevelSelection") {
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
