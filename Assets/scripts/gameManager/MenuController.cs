﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

	public void PlayGame () {
		SceneManager.LoadScene ("main", LoadSceneMode.Single);
	}
}
