using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.NetworkSystem;
using System;

public class Uzvara : MonoBehaviour {

	public GameObject uzvaraLogs;
	public GameObject timer;
	public Text uzvLaiks;

	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;

	public Sprite Star_full;
	public Sprite Star_empty;

	// Use this for initialization
	void Start () {
		uzvaraLogs.SetActive (false);
	}

	public void endGame() {
		GetComponent<SpriteRenderer> ().sprite = Star_empty;
		timer.SetActive (false);
		uzvaraLogs.SetActive (true);

		uzvLaiks.text = timer.getTime (false);
		int s = Convert.ToInt32 (timer.getTime (true));

		if (s / 60 < 2) {
			GetComponent<SpriteRenderer> ().sprite = Star_full;

		} else if (s / 60 < 3) {

		} else {

		}
	}
}
