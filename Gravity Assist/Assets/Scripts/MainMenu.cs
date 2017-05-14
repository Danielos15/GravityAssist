using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // switch scenes

public class MainMenu : MonoBehaviour {

	GameManager gameManager;
	public GameObject aboutPanel;
	public GameObject mainMenuPanel;
	public GameObject levelPanel;
	public GameObject settingsPanel;
	public GameObject startPanel;
	public GameObject requiredPanel;
	public GameObject clearProgressPanel;

	private bool aboutIsActive;
	private bool settingsIsActive;

	void Awake() {
	}

	public void ButtonMenu(Button button) {

		if (button.name == "Start") {
			levelPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
		}

		if (button.name == "Settings") {
			settingsIsActive = true;
			settingsPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
			print ("Settings");
		}

		if (button.name == "Clear") {
			clearProgressPanel.SetActive (true);
			settingsPanel.SetActive (false);
		}

		if (button.name == "YesClear") {
			PlayerPrefs.DeleteAll ();
			startPanel.SetActive (true);
			clearProgressPanel.SetActive (false);
		} 

		if (button.name == "NoClear") {
			clearProgressPanel.SetActive (false);
			settingsPanel.SetActive (true);
		}


		if (button.name == "Quit") {
			Application.Quit ();
			print ("Quitting game");
		}

		if (button.name == "About") {
			aboutIsActive = true;
			aboutPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
		}

		if (button.name == "Settings") {
			settingsPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
		}

		if (button.name == "BackButton") {
			if (aboutIsActive) {
				aboutPanel.SetActive (false);
				mainMenuPanel.SetActive (true);
				aboutIsActive = false;
			}

			if (settingsIsActive) {
				settingsPanel.SetActive (false);
				mainMenuPanel.SetActive (true);
				settingsIsActive = false;
			}
		}
			
		if (button.name == "BackButton2") {
			settingsPanel.SetActive (false);
			mainMenuPanel.SetActive (true);
		}

		if (button.name == "LevelBackButton") {
			levelPanel.SetActive (false);
			mainMenuPanel.SetActive (true);
		}

		if (button.name == "Continue") {
			string name = startPanel.GetComponentInChildren<InputField> ().text;
			if (name.Length == 0) {
				requiredPanel.SetActive (true);
				// DO NOTHING
			}
			if (name.Length > 0) {
				startPanel.SetActive (false);
				mainMenuPanel.SetActive (true);
				GameOptions.getInstance ().setName (name);
			}
		}
	}
}
