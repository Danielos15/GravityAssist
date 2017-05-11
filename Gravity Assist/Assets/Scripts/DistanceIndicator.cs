using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceIndicator : MonoBehaviour {

	private bool insideView = true;
	private Camera camera;
	private float distanceFromEdge;
	private Transform spaceship;
	public GameObject indicator;
	private GameObject indicatorObject;
	private Transform indicatorTrans;
	private float imageWidth;
	private float imageHeight;
	private Transform textTrans;
	private TextMesh textMesh;

	void Awake () {
		spaceship = GetComponentInParent<Transform> ();
		camera = Camera.main;
		indicatorObject = Instantiate (indicator);
		indicatorObject.SetActive (false);
		indicatorTrans = indicatorObject.GetComponent<Transform> ();
		imageWidth = (indicatorTrans.GetComponent<SpriteRenderer> ().sprite.rect.width * indicatorTrans.localScale.x) / 3;
		imageHeight = (indicatorTrans.GetComponent<SpriteRenderer> ().sprite.rect.height * indicatorTrans.localScale.y) / 3;
		textMesh = indicatorObject.GetComponentInChildren<TextMesh> ();
		textTrans = indicatorTrans.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (indicatorObject.activeSelf && insideView) {
			indicatorObject.SetActive (false);
		}

		if (!insideView) {
			Vector2 cords = camera.WorldToScreenPoint (spaceship.position);

			Vector2 indicatorPos = new Vector2 (
				Mathf.Clamp (cords.x, imageWidth, camera.pixelWidth - imageWidth),
				Mathf.Clamp (cords.y, imageHeight, camera.pixelHeight - imageHeight)
			);
			Vector3 tempVector = camera.ScreenToWorldPoint(indicatorPos);
			tempVector.z = 0;
			indicatorTrans.position = tempVector;
			Quaternion rotation = CalculateAngle (indicatorTrans.position, spaceship.position);
			indicatorTrans.rotation = rotation;
			float distance = Vector2.Distance (indicatorTrans.position, spaceship.position);
			textMesh.text = distance.ToString("F1");
			textTrans.localEulerAngles = new Vector3(0, 0, -indicatorTrans.rotation.eulerAngles.z);

			if (!indicatorObject.activeSelf) {
				indicatorObject.SetActive (true);
			}
		}
	}
		
	void OnBecameInvisible() {
		insideView = false;
	}

	void OnBecameVisible() {
		insideView = true;
	}

	Quaternion CalculateAngle(Vector2 startPosition, Vector2 endPosition) {
		Vector2 tempAngle = endPosition - startPosition;
		float rotation = Mathf.Atan2(tempAngle.y,tempAngle.x) * Mathf.Rad2Deg + 90;
		return Quaternion.Euler(0.0f, 0.0f, rotation);
	}
}
