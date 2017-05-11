using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

	GameController gameManager;
	public GameObject gameOverPanel;
	public GameObject levelWonPanel;
	public Text scoreText;
	public GameObject explosion;
	public AudioSource explosionSound;
	public AudioSource vortexSound;

	private Transform trans;
	private Rigidbody2D rigid;
	private CapsuleCollider2D shipCollider;
	public float finishDelay;

	private PlayerMovementMouse pm;

	// Use this for initialization
	void Start () {
		shipCollider = GetComponent<CapsuleCollider2D> ();
		trans = GetComponent<Transform> ();
		rigid = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		pm = GetComponent<PlayerMovementMouse> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.gameObject.tag == "Astroid" || other.gameObject.tag == "CelestialObject") && gameManager.isStarted()) {
			Instantiate (explosion, transform.position, transform.rotation);
			explosionSound.Play ();
			Destroy (gameObject);
			gameOverPanel.SetActive(true);

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
				pm.SetEndTime (Time.time);
				gameManager.endGame();
				finishDelay -= Time.deltaTime;
				rigid.velocity = Vector2.zero;
				trans.position = Vector2.Lerp (trans.position, other.GetComponent<Transform> ().position, 0.1f);
				trans.Rotate (trans.forward * 240 * Time.deltaTime);
				trans.localScale = Vector3.Lerp (trans.localScale, new Vector3 (0.01f, 0.01f, 0.01f), 0.05f);
				vortexSound.Play ();
			} else {
				Destroy (gameObject);
				shipCollider.isTrigger = false;
				scoreText.text = "Score: " + Mathf.Round(pm.GetScore());
				levelWonPanel.SetActive (true);
			}
		}
	}
}
