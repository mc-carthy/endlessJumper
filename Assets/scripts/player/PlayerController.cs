using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	private Rigidbody2D rb;
	private Animator anim;
	[SerializeField]
	private float forceX, forceY;
	private float thresholdX = 7f;
	private float thresholdY = 14f;
	private bool setPower, didJump;

	private void Awake () {
		MakeInstance ();
		Initialize ();
	}

	private void Update () {
		SetPower ();
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (didJump) {
			didJump = false;
			if (trig.tag == "platform") {
				if (GameManager.instance != null) {
					GameManager.instance.CreateNewPlatformAndLerp (trig.transform.position.x);
				}
			}
		}
	}

	public void SetPower (bool setPower) {
		this.setPower = setPower;

		if (setPower) {

		} else {
			Jump ();
		}
	}

	private void Initialize () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	private void SetPower () {
		if (setPower) {
			forceX += thresholdX * Time.deltaTime;
			forceY += thresholdY * Time.deltaTime;

			if (forceX > 6.5f) {
				forceX = 6.5f;
			}

			if (forceY > 13.5f) {
				forceY = 13.5f;
			}
		}
	}

	private void Jump() {
		rb.velocity = new Vector2 (forceX, forceY);
		forceX = forceY = 0;
		didJump = true;
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
}
