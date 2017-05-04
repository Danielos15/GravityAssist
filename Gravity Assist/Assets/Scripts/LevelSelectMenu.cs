using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour {

	GameManager gameManager;

	public void levelButtons(Button button) {
		SceneManager.LoadScene ("Levels/"+button.name);
	}
}
