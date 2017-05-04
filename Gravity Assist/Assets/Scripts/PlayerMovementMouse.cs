using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour {

	private Transform trans;
	private Rigidbody2D rigid; 
	public float fuel;
	public float fuelPerSec;
	public float forceForward;
	public float rotateSpeed;
	private GameController gameManager;
	public GameObject afterburners;

	public Vector2 startPosition;
	public Vector2 endPosition;
	public float distance;
	public float angle;
	public bool isLaunched = false;
	private LineRenderer lineRenderer;
	public Color okayColor;
	public Color notOkayColor;

	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
		rigid = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) && !isLaunched) {
			startPosition = Input.mousePosition;
			Vector3 startCords = Camera.main.ScreenToWorldPoint (startPosition);
			startCords.z += 1;
			lineRenderer.startWidth = 0.2f;
			lineRenderer.SetPosition (0, startCords);
		}

		if (Input.GetMouseButton(0) && !isLaunched) {
			endPosition = Input.mousePosition;
			Vector3 endCords = Camera.main.ScreenToWorldPoint (endPosition);
			endCords.z += 1;
			lineRenderer.endWidth = 0.2f;
			lineRenderer.SetPosition (1, endCords);

			distance = Vector2.Distance (startPosition, endPosition);
			if (distance >= fuel) {
				lineRenderer.startColor = notOkayColor;
				lineRenderer.endColor = notOkayColor;
			} else {
				lineRenderer.startColor = okayColor;
				lineRenderer.endColor = okayColor;
			}
		}

		if (Input.GetMouseButtonUp(0) && !isLaunched) {
			distance = Vector2.Distance (startPosition, endPosition);
			lineRenderer.enabled = false;
			if (distance >= fuel) {
				distance = fuel;
			}
			angle = Vector2.Angle (startPosition, endPosition);
	
			Vector2 C = endPosition - startPosition;
			float Angle = Mathf.Atan2(C.y,C.x);
			angle = Angle * Mathf.Rad2Deg;
			angle += 90;
			trans.rotation = Quaternion.Euler(0, 0, angle);
			rigid.AddForce (transform.up * distance * 100000 * Time.deltaTime);
			gameManager.startGame ();
			isLaunched = true;
		}
		trans.up = rigid.velocity;
	}
}
