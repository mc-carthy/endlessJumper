using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	private Text scoreText;
	private int score;

	private void Awake () {
		MakeInstance ();
		scoreText = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<Text> ();
	}

	public void IncrementScore () {
		score++;
		scoreText.text = score.ToString ();
	}

	public int GetScore () {
		return score;
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
}
