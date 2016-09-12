using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[SerializeField]
	private GameObject player, platform;

	private float minX = -2.5f, maxX = 2.5f, minY = -5.7f, maxY = -3.7f;
	private bool lerpCamera;
	private float lerpTime = 1.5f;
	private float lerpX;

	private void Awake () {
		MakeInstance ();
		CreateInitialPlatforms ();
	}

	private void Update () {
		if (lerpCamera) {
			LerpCamera ();
		}
	}

	public void CreateNewPlatformAndLerp (float lerpPosition) {
		CreateNewPlatform ();
		lerpX = lerpPosition + maxX;
		lerpCamera = true;
	}

	private void CreateInitialPlatforms () {
		Vector3 temp = new Vector3 (Random.Range (minX, minX + 1.2f), Random.Range (minY, maxY), 0);
		Instantiate (platform, temp, Quaternion.identity);
		temp.y += 3;
		Instantiate (player, temp, Quaternion.identity);
		temp = new Vector3 (Random.Range (maxX, maxX - 1.2f), Random.Range (minY, maxY), 0);
		Instantiate (platform, temp, Quaternion.identity);
	}

	private void CreateNewPlatform () {
		float cameraX = Camera.main.transform.position.x;

		float newMaxX = (maxX * 2) + cameraX;

		Instantiate(platform, new Vector3 (Random.Range(newMaxX, newMaxX - 1.2f), Random.Range(minY, maxY), 0), Quaternion.identity);
	}

	private void LerpCamera () {
		float x = Camera.main.transform.position.x;

		x = Mathf.Lerp (x, lerpX, lerpTime * Time.deltaTime);

		Camera.main.transform.position = new Vector3 (x, Camera.main.transform.position.y, Camera.main.transform.position.z);

		if (Camera.main.transform.position.x >= (lerpX - 0.07f)) {
			lerpCamera = false;
		}
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
}
