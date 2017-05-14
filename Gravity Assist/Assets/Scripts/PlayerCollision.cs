using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

	GameController gameManager;
	public GameObject gameOverPanel;
	//public GameObject levelWonPanel;
	public GameObject leaderboardsPanel;

	//public Text scoreText;
	public Text[] scoreTexts;
	public GameObject explosion;
	public GameObject asteroidExplosion;
	public AudioSource explosionSound;
	public AudioSource vortexSound;

	private Transform trans;
	private Rigidbody2D rigid;
	private CapsuleCollider2D shipCollider;
	public float finishDelay;
	private bool hasPlayed;

	private PlayerMovementMouse pm;

	// Use this for initialization
	void Start () {
		hasPlayed = false;
		shipCollider = GetComponent<CapsuleCollider2D> ();
		trans = GetComponent<Transform> ();
		rigid = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		pm = GetComponent<PlayerMovementMouse> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (gameManager.isStarted()) {

			if (other.gameObject.tag == "Astroid") {
				Instantiate (asteroidExplosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
				explosionSound.Play ();
				Destroy (gameObject);
				gameOverPanel.SetActive (true);
			}

			if (other.gameObject.tag == "CelestialObject") {
				Instantiate (explosion, transform.position, transform.rotation);
				explosionSound.Play ();
				Destroy (gameObject);
				gameOverPanel.SetActive (true);
			}

		} else if (other.gameObject.tag == "Finish") {
			gameManager.endGame ();
		}
	}


	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "OutofBounds" && gameManager.isStarted()) {
			Destroy (gameObject);
			gameOverPanel.SetActive(true);
			gameManager.endGame ();
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Finish") {
			if (finishDelay > 0.0f) {
				if (!hasPlayed) {
					vortexSound.Play ();
					hasPlayed = true;
				}
				pm.SetEndTime (Time.time);
				gameManager.endGame();
				finishDelay -= Time.deltaTime;
				rigid.velocity = Vector2.zero;
				trans.position = Vector2.Lerp (trans.position, other.GetComponent<Transform> ().position, 0.1f);
				trans.Rotate (trans.forward * 240 * Time.deltaTime);
				trans.localScale = Vector3.Lerp (trans.localScale, new Vector3 (0.01f, 0.01f, 0.01f), 0.05f);
			} else {
				Destroy (gameObject);
				shipCollider.isTrigger = false;
				int score = (int) Mathf.Round(pm.GetScore());
				foreach (Text scoreText in scoreTexts) {
					scoreText.text = "Score: " + score;
				}
				GameOptions.getInstance ().setBestScoreForLevel (score);
				//levelWonPanel.SetActive (true);
				leaderboardsPanel.SetActive (true);
			}
		}
	}
}
