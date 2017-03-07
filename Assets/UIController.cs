﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	private GameObject gameOverText;

	private GameObject runLengthText;

	private float len = 0;

	private float speed = 0.05f;

	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		this.gameOverText = GameObject.Find ("GameOver");
		this.runLengthText = GameObject.Find ("RunLength");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false) {
			this.len += this.speed;
			this.runLengthText.GetComponent<Text> ().text = "Disntace: " + this.len.ToString ("F2") + "m";
		} else {
			if (Input.GetMouseButtonDown(0)) {
				SceneManager.LoadScene ("GameScenes");
			}
		}
	}

	public void GameOver() {
		this.gameOverText.GetComponent<Text> ().text = "GameOver";
		this.isGameOver = true;
	}
}
