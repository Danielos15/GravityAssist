using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour {

	public Color okayColor;
	public Color notOkayColor;
	public float fuel;
	public float forceForward;
	public GameObject afterburners;

	private Transform trans;
	private Rigidbody2D rigid; 
	private GameController gameManager;
	private Vector2 startPosition;
	private Vector2 endPosition;
	private float distance;
	private float angle;
	private bool isLaunched = false;
	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
		rigid = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.startWidth = 0.2f;
		lineRenderer.endWidth = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) && !isLaunched) {
			startPosition = Input.mousePosition;
			Vector3 startCords = Camera.main.ScreenToWorldPoint (startPosition);
			startCords.z += 1;
			lineRenderer.positionCount = 2;
			lineRenderer.SetPosition (0, startCords);
		}

		if (Input.GetMouseButton(0) && !isLaunched) {
			endPosition = Input.mousePosition;
			Vector3 endCords = Camera.main.ScreenToWorldPoint (endPosition);
			endCords.z += 1;
			lineRenderer.SetPosition (1, endCords);

			distance = Vector2.Distance (startPosition, endPosition);
			distance /= 2;
			if (distance >= fuel) {
				lineRenderer.startColor = notOkayColor;
				lineRenderer.endColor = notOkayColor;
			} else {
				lineRenderer.startColor = okayColor;
				lineRenderer.endColor = okayColor;
			}
		}

		if (Input.GetMouseButtonUp(0) && !isLaunched) {
			lineRenderer.enabled = false;
			if (distance >= fuel) {
				distance = fuel;
			}

			Vector2 tempAngle = endPosition - startPosition;
			float Angle = Mathf.Atan2(tempAngle.y,tempAngle.x);
			angle = (Angle * Mathf.Rad2Deg) + 90;
			trans.rotation = Quaternion.Euler(0, 0, angle);
			rigid.AddForce (transform.up * distance * forceForward);
			gameManager.startGame ();
			fuel -= distance;
			isLaunched = true;
		}
		trans.up = rigid.velocity;
	}
}
