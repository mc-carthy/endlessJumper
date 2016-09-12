using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public static GameOverController instance;

	private GameObject gameOverPanel;
	private Animator anim;
	private Button restartBtn, backBtn;
	private Text finalScore;

	private void Awake () {
		MakeInstance ();
		InitializeVariables ();
	}

	public void GameOverShowPanel () {
		gameOverPanel.SetActive (true);
		anim.Play ("fadeIn");
	}

	public void RestartLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
	}

	public void BackToMenu () {
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}

	private void InitializeVariables () {
		gameOverPanel = GameObject.FindGameObjectWithTag ("gameOverPanel");
		anim = gameOverPanel.GetComponent<Animator> ();
		restartBtn = GameObject.FindGameObjectWithTag ("restartButton").GetComponent<Button> ();
		backBtn = GameObject.FindGameObjectWithTag ("backButton").GetComponent<Button> ();
		restartBtn.onClick.RemoveAllListeners ();
		backBtn.onClick.RemoveAllListeners ();
		restartBtn.onClick.AddListener (() => RestartLevel ());
		backBtn.onClick.AddListener (() => BackToMenu ());
		finalScore = GameObject.FindGameObjectWithTag ("finalScore").GetComponent<Text>();
		gameOverPanel.SetActive (false);
	}
		
	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
}
