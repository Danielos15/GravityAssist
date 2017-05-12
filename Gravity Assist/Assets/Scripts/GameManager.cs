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
		if (!GameOptions.getInstance().toLevelSelect) {
			levelPanel.SetActive (false);
		}

		if (!GameOptions.getInstance ().isNameSet ()) {
			mainMenuPanel.SetActive (false);
		} else {
			startPanel.SetActive (false);
		}

		settingsPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
