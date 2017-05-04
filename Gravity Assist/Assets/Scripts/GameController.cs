using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private bool started = false;
	private Camera mainCamera;

	void Awake() {
		//mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		//mainCamera.aspect = 16 / 9;
		//Screen.SetResolution(1600, 900, false);
	}

	public void startGame() {
		started = true;
	}

	public bool isStarted() {
		return started;
	}

	public void endGame() {
		started = false;
	}
}
