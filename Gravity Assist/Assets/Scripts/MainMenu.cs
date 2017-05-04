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

	void Awake() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();			
	}

	public void ButtonMenu(Button button) {

		if (button.name == "Start") {
			levelPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
			print ("Starting game");
		}

		if (button.name == "Quit") {
			Application.Quit ();
			gameManager.gameState = GameManager.GameState.Quit;
			print ("Quitting game");
		}

		if (button.name == "About") {
			gameManager.gameState = GameManager.GameState.About;
			aboutPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
			print ("about");
		}

		if (button.name == "BackButton") {
			gameManager.gameState = GameManager.GameState.Menu;
			aboutPanel.SetActive (false);
			mainMenuPanel.SetActive (true);
		}
	}
}
