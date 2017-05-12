using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public GameObject aboutPanel;
	public GameObject mainMenuPanel;
	public GameObject levelPanel;
	public GameObject settingsPanel;
	public GameObject startPanel;

	// Use this for initialization
	void Awake () {
		aboutPanel.SetActive (false);
		// Activate Sounds HAX!!
		settingsPanel.SetActive (true);
		settingsPanel.SetActive (false);
		mainMenuPanel.SetActive (false);

		if (GameOptions.getInstance ().toLevelSelect) {
			levelPanel.SetActive (true);
			GameOptions.getInstance ().toLevelSelect = false;
		} else {
			if (GameOptions.getInstance ().isNameSet ()) {
				mainMenuPanel.SetActive (true);
			} else {
				startPanel.SetActive (true);
			}
		}
	}
}
