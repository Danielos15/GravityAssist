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

	private bool aboutIsActive;
	private bool settingsIsActive;

	void Awake() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();			
	}

	public void ButtonMenu(Button button) {

		if (button.name == "Start") {
			levelPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
		}

		if (button.name == "Settings") {
			settingsIsActive = true;
			gameManager.gameState = GameManager.GameState.Settings;
			settingsPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
			print ("Settings");
		}

		if (button.name == "Quit") {
			Application.Quit ();
			gameManager.gameState = GameManager.GameState.Quit;
			print ("Quitting game");
		}

		if (button.name == "About") {
			aboutIsActive = true;
			gameManager.gameState = GameManager.GameState.About;
			aboutPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
		}

		if (button.name == "Settings") {
			settingsPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
		}

		if (button.name == "BackButton") {
			if (aboutIsActive) {
				gameManager.gameState = GameManager.GameState.Menu;
				aboutPanel.SetActive (false);
				mainMenuPanel.SetActive (true);
				aboutIsActive = false;
			}

			if (settingsIsActive) {
				gameManager.gameState = GameManager.GameState.Settings;
				settingsPanel.SetActive (false);
				mainMenuPanel.SetActive (true);
				settingsIsActive = false;
			}
		}
			
		if (button.name == "BackButton2") {
			gameManager.gameState = GameManager.GameState.Menu;
			settingsPanel.SetActive (false);
			mainMenuPanel.SetActive (true);
		}

		if (button.name == "LevelBackButton") {
			gameManager.gameState = GameManager.GameState.Menu;
			levelPanel.SetActive (false);
			mainMenuPanel.SetActive (true);
		}

		if (button.name == "Continue") {
			string name = startPanel.GetComponentInChildren<InputField> ().text;
			if (name.Length == 0) {
				// requiredPanel.SetActive (true);
				// DO NOTHING
			}
			if (name.Length > 0) {
				gameManager.gameState = GameManager.GameState.Menu;
				Debug.Log (name);
				startPanel.SetActive (false);
				mainMenuPanel.SetActive (true);
			}
		}
	}
}
