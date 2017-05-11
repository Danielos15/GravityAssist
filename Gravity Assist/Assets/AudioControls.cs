using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControls : MonoBehaviour {

	public AudioSource mainMusic;
	public AudioSource gameSounds;

	// Use this for initialization
	void Start () {
		mainMusic.GetComponent<AudioSource> ();
		gameSounds.GetComponent<AudioSource> ();
	}

	public void musicButtons(Button button){
		if (button.name == "Mute") {
			mainMusic.Pause();
		}
		if (button.name == "On") {
			mainMusic.Play ();
		}
	}

	public void soundButtons(Button button) {
		if (button.name == "Mute") {
			gameSounds.mute = true;
		}
		if (button.name == "On") {
			gameSounds.mute = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
