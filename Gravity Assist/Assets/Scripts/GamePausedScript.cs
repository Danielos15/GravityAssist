using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedScript : MonoBehaviour {

	public GameObject pauseMenuPanel;

	public void buttonMenu(Button button) {
		if (button.name == "Pause") {
			pauseMenuPanel.SetActive (true);
			Time.timeScale = 0;
		}

		if (button.name == "Resume") {
			pauseMenuPanel.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
