using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public void UzSakumu(){
		SceneManager.LoadScene ("Start", LoadSceneMode.Single);
	}

	public void PilsetasKarte(){
		SceneManager.LoadScene ("PilsetasKarte", LoadSceneMode.Single);
	}

	public void Apturet(){
		Application.Quit ();
	}
}