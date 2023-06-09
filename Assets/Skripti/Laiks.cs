using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Laiks : MonoBehaviour {

	public GameObject textBox;	// GameObject, kas satur teksta lauku
	public static float timerStart;
	private static string timer_text;	// Laika rādītāja teksts


	// Use this for initialization
	void Start () {
		timerStart = 0;		// Sākuma taimera vērtība ir 0
		timer_text = getTime(false);	// Iegūstam sākotnējo laiku
		textBox.GetComponent<Text>().text = timer_text;		// Iestatām teksta laukā rādāmo laiku
	}
		

	public static string getTime(bool Seconds) {
		int h, m, s;	// Mainīgie laika vienībam
		string a, b, c;		// Mainīgie laika attēlošanai

		s = Mathf.RoundToInt(timerStart);	// Noapaļojam taimeru
		if (Seconds)
		{
			return ""+s;	// Ja ir pieprasīti tikai sekundes, tad atgriežam tikai sekundes vērtību
		}

		h = s/3600;
		s -= h*3600;
		m = s/60;
		s -= m*60;

		if (s < 10) {
			c = ":0" + s;
		} else {
			c = ":" + s;
		}

		if (m < 10) {
			b = ":0" + m;
		} else {
			b = ":" + m;
		}

		if (h < 10) {
			a = "0" + h;
		} else {
			a = "" + h;
		}

		timer_text = a+b+c;

		return timer_text;
	}


	// Update is called once per frame
	void Update () {
		timerStart += Time.deltaTime;
		timer_text = getTime (false);

		textBox.GetComponent<Text> ().text = timer_text;
	}
}
