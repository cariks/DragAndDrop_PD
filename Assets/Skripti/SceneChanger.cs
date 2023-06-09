using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public void UzSakumu(){		// Metode, kas tiek izsaukta, lai pārslēgtu uz sākuma ainu
		SceneManager.LoadScene ("Start", LoadSceneMode.Single);
	}

	public void PilsetasKarte(){	// Metode, kas tiek izsaukta, lai pārslēgtu uz spēles ainu
		SceneManager.LoadScene ("PilsetasKarte", LoadSceneMode.Single);
		NomesanasVieta.parVietas = 0;
	}

	public void Apturet(){		// Metode, kas tiek izsaukta, lai apturētu programmu
		Application.Quit ();
	}
}