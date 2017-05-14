using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour {
	private static GameOptions _instance;

	private string colPlayerName = "playerName";
	private string colPlayerId = "playerId";
	private string colMusic = "music";
	private string colSoundEffects = "sound";
	private string colHasPlayed = "hasPlayed";

	private string serverName = "https://gravityassist.000webhostapp.com";

	public bool toLevelSelect;
	private bool hasPlayed;

	void Awake() {
		if (!_instance) {
			_instance = this;
			toLevelSelect = false;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public static GameOptions getInstance() {
		return _instance;
	}


	// GETTERS
	public int getId() {
		return getInt (colPlayerId);
	}

	public string getName() {
		return getString (colPlayerName);
	}

	public bool getMusicSettings() {
		return getBool (colMusic);
	}

	public bool getHasPlayed() {
		return getBool (colHasPlayed);
	}

	public bool getSoundSettings() {
		return getBool (colSoundEffects);
	}

	public int getBestScoreForLevel(string levelName) {
		return getInt (levelName);
	}


	// SETTERS
	public void setId(int id) {
		saveInt (colPlayerId, id);
	}

	public void setName(string name) {
		saveString (colPlayerName, name);
		StartCoroutine (getIdFromServer ());
	}

	public void setHasPlayed(bool b) {
		saveBool (colHasPlayed, b);
	}

	public void setMusicSettings(bool b) {
		saveBool (colMusic, b);
	}

	public void setSoundSettings(bool b) {
		saveBool (colSoundEffects, b);
	}

	public void setBestScoreForLevel(int score) {
		string levelName = SceneManager.GetActiveScene ().name;
		if (isScoreBetter (levelName, score)) {
			saveInt (levelName, score);
			StartCoroutine (SendScoreToServer (score));
		} else {
			StartCoroutine (getScoreFromServerByLevel());
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

	// Networking
	IEnumerator getIdFromServer() {
		WWWForm form = new WWWForm();
		form.AddField( "name", getName() );
		UnityWebRequest www = UnityWebRequest.Post(serverName + "/user", form);

		yield return www.Send();

		if(www.isError) {
			Debug.Log(www.error);
		}
		else {
			ServerRequest request = JsonUtility.FromJson<ServerRequest>(www.downloadHandler.text);
			if (request.success) {
				setId (request.id);
			}
		}
	}

	IEnumerator SendScoreToServer(int score) {
		WWWForm form = new WWWForm();
		form.AddField( "score", score );
		UnityWebRequest www = UnityWebRequest.Post(serverName + "/score/" + SceneManager.GetActiveScene().name + "/" + getId(), form);

		yield return www.Send();

		if(www.isError) {
			Debug.Log(www.error);
			// TODO Check if it was not successfull
		}
		else {

			Debug.Log (www.downloadHandler.text);
			ServerRequest request = JsonUtility.FromJson<ServerRequest>(www.downloadHandler.text);
			StartCoroutine (getScoreFromServerByLevel());
			if (!request.success) {
				// TODO Check if it was not successfull.
			}
		}
	}

	IEnumerator getScoreFromServerByLevel() {
		UnityWebRequest www = UnityWebRequest.Get(serverName + "/score/" + SceneManager.GetActiveScene().name);

		yield return www.Send();

		if(www.isError) {
			Debug.Log(www.error);
			// TODO Check if it was not successfull
		}
		else {
			Debug.Log (www.downloadHandler.text);
			Score[] scores = JsonHelper.FromJson<Score>(www.downloadHandler.text);
			if (scores.Length > 0) {
				GameObject scoreList = GameObject.FindGameObjectWithTag ("ScoreList");
				scoreList.GetComponent<Scorelist> ().setScore (scores);

			}
		}
	}
}