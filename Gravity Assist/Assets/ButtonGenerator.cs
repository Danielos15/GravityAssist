using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGenerator : MonoBehaviour {

	public GameObject buttonPrefab;
	public GameObject parent;
	const int levelCount = 5;
	const int add = -75;
	private LevelSelectMenu test1;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		int x = 1;
		parent.GetComponent<RectTransform> ().sizeDelta.Set (450, (levelCount * 160));

		//parent.GetComponent<RectTransform> ();
		for (int i = 0; i < levelCount; i++) {
			GameObject button = Instantiate (buttonPrefab);
			button.transform.SetParent(parent.transform);
			//var rectTransform = button.GetComponent<RectTransform> ();
			//rectTransform.position.Set (300, (150 * i + (add) + 40), 0);
			button.transform.GetChild (0).GetComponent<Text> ().text = ("Level " + x );
			button.name = ("Level_" + x);
			Button test = button.GetComponent<Button> ();
			test.onClick.AddListener ( () => levelButtons(test));
			x++;
		}


	}

	public void levelButtons(Button button) {
		audio.Play ();
		SceneManager.LoadScene ("Levels/"+button.name);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
