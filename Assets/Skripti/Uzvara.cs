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

		Debug.Log("Spēle ir pabeigta");

		Star3.GetComponent<Image> ().sprite = Star_empty;
		Star2.GetComponent<Image> ().sprite = Star_empty;
		Star1.GetComponent<Image> ().sprite = Star_empty;

		timer.SetActive (false);
		uzvaraLogs.SetActive (true);

		uzvLaiks.text = Laiks.getTime (false);
		int s = Convert.ToInt32 (Laiks.getTime (true));

		if (s / 60 < 2) {
			Star3.GetComponent<Image> ().sprite = Star_full;
			Star2.GetComponent<Image> ().sprite = Star_full;
			Star1.GetComponent<Image> ().sprite = Star_full;

		} else if (s / 60 < 3) {
			Star2.GetComponent<Image> ().sprite = Star_full;
			Star1.GetComponent<Image> ().sprite = Star_full;

		} else {
			Star1.GetComponent<Image> ().sprite = Star_full;

		}
	}
}
