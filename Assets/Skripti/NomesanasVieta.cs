using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NomesanasVieta : MonoBehaviour, 
	IDropHandler{
	private float vietasZRot, velkObjZRot, rotacijasStarpiba;	// Mainīgie rotācijas aprēķiniem
	private Vector2 vietasIzm, velkObjIzm;		// Mainīgie izmēru aprēķiniem
	private float xIzmStarpiba, yIzmStarpiba;		// Mainīgie izmēru starpībai
	public Objekti objektuSkripts;

	public static int parVietas = 0; // Pareizi piegādāto mašīnu skaits


    public void OnDrop(PointerEventData eventData)
    {
		if (eventData.pointerDrag != null)
		{
			if (eventData.pointerDrag.tag.Equals(tag))	// Pārbauda, vai vilktā objekta tag atbilst šīs vietas tag
			{
				vietasZRot =
				eventData.pointerDrag.
					GetComponent<RectTransform>().transform.eulerAngles.z;	// Iegūst šīs vietas rotācijas leņķi

				velkObjZRot =
					GetComponent<RectTransform>().transform.eulerAngles.z;	// Iegūst šīs vietas rotācijas leņķi

				rotacijasStarpiba =
					Mathf.Abs(vietasZRot - velkObjZRot);	// Aprēķina rotācijas starpību
				

				vietasIzm =
				eventData.pointerDrag.
					GetComponent<RectTransform>().localScale;	// Iegūst šīs vietas izmērus

				velkObjIzm =
					GetComponent<RectTransform>().localScale;	// Iegūst nomestā objekta izmērus

				xIzmStarpiba = Mathf.Abs(vietasIzm.x - velkObjIzm.x);	// Aprēķina platuma starpību
				yIzmStarpiba = Mathf.Abs(vietasIzm.y - velkObjIzm.y);	// Aprēķina augstuma starpību

				Debug.Log("Objektu rotācijas starpība: " + rotacijasStarpiba
					+ "\nPlatuma starpība: " + xIzmStarpiba +
					"\nAugstuma starpība: " + yIzmStarpiba);


				// Pārbauda, vai objekts ir nomests pareizajā vietā, salīdzinot rotāciju un izmērus
				if ((rotacijasStarpiba <= 6 ||
					(rotacijasStarpiba >= 354 && rotacijasStarpiba <= 360))
					&& (xIzmStarpiba <= 0.1 && yIzmStarpiba <= 0.1))
				{
					Debug.Log("Nomests pareizajā vietā!");
                    objektuSkripts.vaiIstajaVieta = true;


					// Iestata nomestā objekta pozīciju, rotāciju un izmērus uz šīs vietas vērtībām
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
						= GetComponent<RectTransform>().anchoredPosition;

					eventData.pointerDrag.GetComponent<RectTransform>().localRotation =
						GetComponent<RectTransform>().localRotation;

					eventData.pointerDrag.GetComponent<RectTransform>().localScale =
						GetComponent<RectTransform>().localScale;


					parVietas++;	// Palielina pareizi nomestu objektu skaitītāju

					// Atskaņo skaņas atkarībā no nomestā objekta tag
					switch (eventData.pointerDrag.tag) {
					case "atkritumi":
						objektuSkripts.skanasAvots.PlayOneShot (
							objektuSkripts.skanasKoAtskanot [1]);
						
							break;

						case "atrie":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[2]);
							break;

						case "buss":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[3]);
							break;



						case "traktori5":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[4]);
							break;

						case "traktori1":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[5]);
							break;

						case "eskavatori":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[6]);
							break;

						case "b2s":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[7]);
							break;

						case "cementi":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[8]);
							break;

						case "e46s":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[9]);
							break;

						case "e61s":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[10]);
							break;

						case "policisti":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[11]);
							break;

						case "uguni":
							objektuSkripts.skanasAvots.PlayOneShot(
								objektuSkripts.skanasKoAtskanot[12]);
							break;



						default:
							Debug.Log("Tags nav definēts!");
							break;
					}


					// Pārbauda, vai visi objekti ir pareizi nomesti, ja ir, izsauc uzvara funkciju
					if (parVietas == 12) {

						Uzvara uzvParadisana = FindObjectOfType<Uzvara>();
						uzvParadisana.endGame ();
						parVietas = 0;
					}
				}


			} else	{
				objektuSkripts.vaiIstajaVieta = false; 	// Iestata, ka objekts nav pareizi nomests
				objektuSkripts.skanasAvots.PlayOneShot(
					objektuSkripts.skanasKoAtskanot[0]);	// Atskaņo nepareizas vietas skaņu

				switch (eventData.pointerDrag.tag){		// Atgriež objektu sākotnējās koordinātēs
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
