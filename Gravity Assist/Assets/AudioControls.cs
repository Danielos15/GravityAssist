using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControls : MonoBehaviour {

	public AudioSource mainMusic;
	public AudioSource gameSounds;

	// Use this for initialization
	void Awake () {
		if (!GameOptions.getInstance ().getMusicSettings ()) {
			mainMusic.mute = true;
		}
		if (!GameOptions.getInstance ().getSoundSettings ()) {
			gameSounds.mute = true;
		}
	}

	public void musicButtons(Button button){
		if (button.name == "Mute") {
			GameOptions.getInstance().setMusicSettings(false);
			mainMusic.mute = true;
		}
		if (button.name == "On") {
			GameOptions.getInstance().setMusicSettings(true);
			mainMusic.mute = false;
		}
	}

	public void soundButtons(Button button) {
		if (button.name == "Mute") {
			GameOptions.getInstance ().setSoundSettings (false);
			gameSounds.mute = true;
		}
		if (button.name == "On") {
			GameOptions.getInstance ().setSoundSettings (true);
			gameSounds.mute = false;
		}
	}
}
