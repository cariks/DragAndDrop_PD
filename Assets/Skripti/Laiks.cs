using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Laiks : MonoBehaviour {
	public static float timerStart;
	public GameObject textBox;

	private static string t;


	// Use this for initialization
	void Start () {
		timerStart = 0;
		t = getTime(false);
		textBox.GetComponent<Text>().text = t;
	}
		

	public static string getTime(bool Seconds) {
		int h, m, s;
		s = Mathf.RoundToInt(timerStart);
		if (Seconds)
		{
			return ""+s;
		}

		h = s/3600;
		s -= h*3600;
		m = s/60;
		s -= m*60;

		string a, b, c;

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

		t = a+b+c;

		return t;
	}



	// Update is called once per frame
	void Update () {
		timerStart += Time.deltaTime;
		t = getTime (false);

		textBox.GetComponent<Text> ().text = t;
	}
}
