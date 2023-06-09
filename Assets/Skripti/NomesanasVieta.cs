using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NomesanasVieta : MonoBehaviour, 
	IDropHandler{
	private float vietasZRot, velkObjZRot, rotacijasStarpiba;
	private Vector2 vietasIzm, velkObjIzm;
	private float xIzmStarpiba, yIzmStarpiba;
	public Objekti objektuSkripts;

	private static int parVietas = 0;

    public void OnDrop(PointerEventData eventData)
    {
		if (eventData.pointerDrag != null)
		{
			if (eventData.pointerDrag.tag.Equals(tag))
			{
				vietasZRot =
				eventData.pointerDrag.
				GetComponent<RectTransform>().transform.eulerAngles.z;

				velkObjZRot =
				GetComponent<RectTransform>().transform.eulerAngles.z;

				rotacijasStarpiba =
				Mathf.Abs(vietasZRot - velkObjZRot);

				vietasIzm =
				eventData.pointerDrag.
				GetComponent<RectTransform>().localScale;

				velkObjIzm =
					GetComponent<RectTransform>().localScale;

				xIzmStarpiba = Mathf.Abs(vietasIzm.x - velkObjIzm.x);
				yIzmStarpiba = Mathf.Abs(vietasIzm.y - velkObjIzm.y);

				Debug.Log("Objektu rotācijas starpība: " + rotacijasStarpiba
					+ "\nPlatuma starpība: " + xIzmStarpiba +
					"\nAugstuma starpība: " + yIzmStarpiba);


				if ((rotacijasStarpiba <= 6 ||
					(rotacijasStarpiba >= 354 && rotacijasStarpiba <= 360))
					&& (xIzmStarpiba <= 0.1 && yIzmStarpiba <= 0.1))
				{
					Debug.Log("Nomests pareizajā vietā!");
                    objektuSkripts.vaiIstajaVieta = true;


                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
						= GetComponent<RectTransform>().anchoredPosition;

					eventData.pointerDrag.GetComponent<RectTransform>().localRotation =
						GetComponent<RectTransform>().localRotation;

					eventData.pointerDrag.GetComponent<RectTransform>().localScale =
						GetComponent<RectTransform>().localScale;



					switch (eventData.pointerDrag.tag) {
					case "atkritumi":
						objektuSkripts.skanasAvots.PlayOneShot (
							objektuSkripts.skanasKoAtskanot [1]);
						parVietas++;
							break;

						case "atrie":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[2]);
						parVietas++;
							break;

						case "buss":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[3]);
						parVietas++;
							break;



						case "traktori5":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[4]);
						parVietas++;
							break;

						case "traktori1":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[5]);
						parVietas++;
							break;

						case "eskavatori":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[6]);
						parVietas++;
							break;

						case "b2s":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[7]);
						parVietas++;
							break;

						case "cementi":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[8]);
						parVietas++;
							break;

						case "e46s":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[9]);
						parVietas++;
							break;

						case "e61s":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[10]);
						parVietas++;
							break;

						case "policisti":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[11]);
						parVietas++;
							break;

						case "uguni":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[12]);
						parVietas++;
							break;



						default:
							Debug.Log("Tags nav definēts!");
							break;
					}



					if (parVietas == 12) {

						Uzvara uzvParadisana = FindObjectOfType<Uzvara>();
						uzvParadisana.endGame ();
					}
				}


				//Ja tagi nesakrīt, tātad nepareizajā vietā
			} else	{
				objektuSkripts.vaiIstajaVieta = false;
				objektuSkripts.skanasAvots.PlayOneShot(
					objektuSkripts.skanasKoAtskanot[0]);

                switch (eventData.pointerDrag.tag){
                    case "atkritumi":
						objektuSkripts.atkritumuMasina.
						GetComponent<RectTransform>().localPosition =
						objektuSkripts.atkrMKoord;
                        break;

                    case "atrie":
                        objektuSkripts.atraPalidziba.
                        GetComponent<RectTransform>().localPosition =
                        objektuSkripts.atrPKoord;
                        break;

                    case "buss":
                        objektuSkripts.autobuss.
                         GetComponent<RectTransform>().localPosition =
                         objektuSkripts.bussKoord;
                        break;


				case "traktori5":
					objektuSkripts.traktors5.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.traktors5Koord;
					break;

				case "traktori1":
					objektuSkripts.traktors1.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.traktors1Koord;
					break;

				case "eskavatori":
					objektuSkripts.eskavators.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.eskavatorsKoord;
					break;

				case "b2s":
					objektuSkripts.b2.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.b2Koord;
					break;

				case "cementi":
					objektuSkripts.cementaMasina.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.cementaMasinaKoord;
					break;

				case "e46s":
					objektuSkripts.e46.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.e46Koord;
					break;

				case "e61s":
					objektuSkripts.e61.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.e61Koord;
					break;

				case "policisti":
					objektuSkripts.policija.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.policijaKoord;
					break;

				case "uguni":
					objektuSkripts.ugunsdzesejs.
					GetComponent<RectTransform>().localPosition =
						objektuSkripts.ugunsdzesejsKoord;
					break;



                    default:
                        Debug.Log("Tags nav definēts!");
                        break;
                }
            }
		}
		
	}
}
