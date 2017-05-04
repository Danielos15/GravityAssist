using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	//GameManager gameManager;
	Scene scene;

	public GameObject replayPanel;
	public GameObject mainMenuPanel;
	public Object nextScene;

	/*void Awake() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		gameOverPanel = GameObject.FindGameObjectWithTag ("GameOver").GetComponent<GameOverMenu> ();
	}*/


	public void ButtonMenu(Button button) {
		if (button.name == "MainMenu") {
			SceneManager.LoadScene ("MainMenu");

			//gameManager.gameState = GameManager.GameState.Start;

			print ("Starting game");
		}

		if (button.name == "Restart") {
			scene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (scene.name);
		}

		if (button.name == "NextLevel") {
			SceneManager.LoadScene (nextScene.name);
		}
	}

}
