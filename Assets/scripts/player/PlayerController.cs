using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	private Rigidbody2D rb;
	private Animator anim;
	private float forceX, forceY;
	private float thresholdX = 7f;
	private float thresholdY = 14f;
	private bool setPower, didJump;

	private void Awake () {
		MakeInstance ();
	}

	private void Update () {

	}

	public void SetPower (bool setPower) {
		this.setPower = setPower;

		if (setPower) {

		} else {

		}
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
}
