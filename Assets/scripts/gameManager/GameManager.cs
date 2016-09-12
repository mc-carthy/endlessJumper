using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[SerializeField]
	private GameObject player, platform;

	private float minX = -2.5f, maxX = 2.5f, minY = -5.7f, maxY = -3.7f;

	private void Awake () {
		MakeInstance ();
		CreateInitialPlatforms ();
	}

	private void CreateInitialPlatforms () {
		Vector3 temp = new Vector3 (Random.Range (minX, minX + 1.2f), Random.Range (minY, maxY), 0);
		Instantiate (platform, temp, Quaternion.identity);
		temp.y += 3;
		Instantiate (player, temp, Quaternion.identity);
		temp = new Vector3 (Random.Range (maxX, maxX - 1.2f), Random.Range (minY, maxY), 0);
		Instantiate (platform, temp, Quaternion.identity);
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
}
