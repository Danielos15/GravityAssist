using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour {
	private static GameOptions _instance;

	private string colPlayerName = "playerName";
	private string colMusic = "music";
	private string colSoundEffects = "sound";

	void Awake() {
		if (!_instance) {
			_instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public static GameOptions getInstance() {
		return _instance;
	}


	// GETTERS
	public string getName() {
		return getString (colPlayerName);
	}

	public bool getMusicSettings() {
		return getBool (colMusic);
	}

	public bool geSoundSettings() {
		return getBool (colSoundEffects);
	}

	public int getBestScoreForLevel(string levelName) {
		return getInt (levelName);
	}


	// SETTERS
	public void setName(string name) {
		saveString (colPlayerName, name);
	}

	public void setMusicSettings(bool b) {
		saveBool (colMusic, b);
	}

	public void setSoundSettings(bool b) {
		saveBool (colSoundEffects, b);
	}

	public void setBestScoreForLevel(string levelName, int score) {
		if (isScoreBetter(levelName, score)) {
			saveInt (levelName, score);
		}
	}


	// CHECKERS
	public bool isNameSet() {
		return PlayerPrefs.HasKey (colPlayerName);
	}

	public bool isScoreBetter(string levelName, int score) {
		int currentBest = getInt (levelName);
		if (score > currentBest) {
			return true;
		}
		return false;
	}

	public bool isLevelDone(string levelName) {
		return PlayerPrefs.HasKey (levelName);
	}


	// Get from PlayerPrefs
	private string getString(string key) {
		return PlayerPrefs.GetString (key, "");
	}

	private int getInt(string key) {
		return PlayerPrefs.GetInt (key, 0);
	}

	private bool getBool(string key) {
		return (PlayerPrefs.GetInt (key, 0) != 0);
	}


	// Save to PlayerPrefs
	private void saveString(string key, string s) {
		PlayerPrefs.SetString (key, s);
		save ();
	}

	private void saveInt(string key, int i) {
		PlayerPrefs.SetInt (key, i);
		save ();
	}

	private void saveBool(string key, bool b) {
		PlayerPrefs.SetInt (key, (b ? 1 : 0));
		save ();
	}

	//Save to file
	private void save() {
		PlayerPrefs.Save ();
	}
}