using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private bool started = false;

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
