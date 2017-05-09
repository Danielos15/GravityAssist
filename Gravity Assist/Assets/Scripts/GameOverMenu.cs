﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	//GameManager gameManager;
	Scene scene;

	public GameObject replayPanel;
	public GameObject mainMenuPanel;
	//public GameObject gamePausedPanel;

	public Object nextScene;

	/*void Awake() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		gameOverPanel = GameObject.FindGameObjectWithTag ("GameOver").GetComponent<GameOverMenu> ();
	}*/

	public void ButtonMenu(Button button) {
		if (button.name == "MainMenu") {
			Time.timeScale = 1;
			SceneManager.LoadScene ("MainMenu");

			//gameManager.gameState = GameManager.GameState.Start;

			print ("Starting game");
		}

		if (button.name == "Restart") {
			Time.timeScale = 1;
			scene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (scene.name);
		}
			
		if (button.name == "NextLevel") {
			Time.timeScale = 1;
			Debug.Log (SceneManager.GetActiveScene ().name);
			if (SceneManager.GetActiveScene ().name == "level_1") {
				SceneManager.LoadScene ("Levels/level_2");
			}
			if (SceneManager.GetActiveScene ().name == "level_2") {
				SceneManager.LoadScene ("Levels/level_3");
			}
			if (SceneManager.GetActiveScene ().name == "level_3") {
				SceneManager.LoadScene ("MainMenu");
			}
		}
	}

}
