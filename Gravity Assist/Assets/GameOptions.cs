using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour {
	private static GameOptions _instance;
	private static bool soundOn;

	void Awake() {
		if (!_instance) {
			soundOn = true;
			_instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public static GameOptions GetInstance() {
		return _instance;
	}


	public bool isSoundOn() {
		return soundOn;
	}

}