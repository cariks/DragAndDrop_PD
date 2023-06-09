using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.NetworkSystem;
using System;

public class Uzvara : MonoBehaviour {

	public GameObject uzvaraLogs;	// Spēles beigās parādāmā uzvaras loga objekts kas satur citus objektus
	public GameObject ButtonAtpakal;
	public GameObject timer;
	public Text uzvLaiks;	// Laiks, kas tiek parādīts uzvaras logā

	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;

	public Sprite Star_full;	// Pilna zvaigzne textūra
	public Sprite Star_empty;	// Tukša zvaigzne textūra


	// Use this for initialization
	void Start () {		// Sākuma uzvaras logs ir paslēpts
		ButtonAtpakal.SetActive (true);
		uzvaraLogs.SetActive (false);
	}

	public void endGame() {		// Metode, kas tiek izsaukta, kad spēle beidzas

		// Nomaina zvaigžņu sprite uz tukšu
		Star3.GetComponent<Image> ().sprite = Star_empty;
		Star2.GetComponent<Image> ().sprite = Star_empty;
		Star1.GetComponent<Image> ().sprite = Star_empty;

		timer.SetActive (false);	// Paslēpj taimeri
		uzvaraLogs.SetActive (true);	// Parāda uzvaras logu
		ButtonAtpakal.SetActive (false);	// Paslēpj "Atpakaļ" pogu

		uzvLaiks.text = Laiks.getTime (false);	  // Saglabā uzvaras laiku no taimera
		int s = Convert.ToInt32 (Laiks.getTime (true));		// Pārvērš laika tekstu sekundēs

		if (s / 60 < 2) {
			// Ja uzvarētāja laiks ir mazāks par divām minūtēm, 3 zvaigžņu objekti maina savas tekstūras uz pilnus
			Star3.GetComponent<Image> ().sprite = Star_full;
			Star2.GetComponent<Image> ().sprite = Star_full;
			Star1.GetComponent<Image> ().sprite = Star_full;

		} else if (s / 60 < 3) {
			// Ja uzvarētāja laiks ir mazāks par trim minūtēm, 2 zvaigžņu objekti maina savas tekstūras uz pilnus
			Star2.GetComponent<Image> ().sprite = Star_full;
			Star1.GetComponent<Image> ().sprite = Star_full;

		} else {
			// Ja uzvarētāja laiks ir lielāks par trim minūtēm, 1 zvaigžņu objekts maina savu tekstūru uz pilnu
			Star1.GetComponent<Image> ().sprite = Star_full;

		}
	}
}
