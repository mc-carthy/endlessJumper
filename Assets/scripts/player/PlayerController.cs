using UnityEngine;
using UnityEngine.UI;
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
	private Slider powerbar;
	private float powerarThreshold = 1f;
	private float powerbarValue;

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
			anim.SetBool ("jump", didJump);
			if (trig.tag == "platform") {
				if (GameManager.instance != null) {
					GameManager.instance.CreateNewPlatformAndLerp (trig.transform.position.x);
				}
				if (ScoreManager.instance != null) {
					ScoreManager.instance.IncrementScore ();
				}
			}
		}

		if (trig.tag == "dead") {
			if (GameOverController.instance != null) {
				GameOverController.instance.GameOverShowPanel ();
			}
			Destroy (gameObject);
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
		powerbar = GameObject.FindGameObjectWithTag ("powerbar").GetComponent<Slider> ();;

		powerbar.minValue = 0f;
		powerbar.maxValue = 1f;
		powerbarValue = powerbarValue;
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
			powerbarValue = forceX / 6.5f;
			powerbar.value = powerbarValue;
		}
	}

	private void Jump() {
		rb.velocity = new Vector2 (forceX, forceY);
		forceX = forceY = 0;
		didJump = true;
		anim.SetBool ("jump", didJump);

		powerbarValue = 0;
		powerbar.value = powerbarValue;
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
}
