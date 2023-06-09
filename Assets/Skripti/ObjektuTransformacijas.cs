using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektuTransformacijas : MonoBehaviour {
	public Objekti objektuSkripts;

	void Update()
	{
		if (objektuSkripts.pedejaisVilktais != null)	// Pārbauda, vai ir norādīts pedejais vilktais objekts
		{
			if (Input.GetKey(KeyCode.Z))	// Pārbauda, vai ir nospiests "Z"
			{
				objektuSkripts.pedejaisVilktais.
				GetComponent<RectTransform>().Rotate(0, 0, Time.deltaTime * 30f);	// Rotē pedejo vilkto objektu pa pulksteņa rādītāja virzienu ar noteiktu ātrumu
			}

			if (Input.GetKey(KeyCode.X))	// Pārbauda, vai ir nospiests "X"
			{
				objektuSkripts.pedejaisVilktais.
				GetComponent<RectTransform>().Rotate(0, 0, -Time.deltaTime * 30f);	// Rotē pedejo vilkto objektu pretējā virzienā pa pulksteņa rādītāja virzienu ar noteiktu ātrumu
			}

			if (Input.GetKey(KeyCode.UpArrow))	// Pārbauda, vai ir nospiests "↑"
			{
				// Palielina pedejo vilkto objektu pa Y ass virzienu, ja tā skalas y vērtība ir mazāka par 1
				if (objektuSkripts.pedejaisVilktais.
					GetComponent<RectTransform>().transform.localScale.y <= 1f)
				{
					objektuSkripts.pedejaisVilktais.
						GetComponent<RectTransform>().transform.localScale =
						new Vector2(objektuSkripts.pedejaisVilktais.
						GetComponent<RectTransform>().transform.localScale.x,
						objektuSkripts.pedejaisVilktais.
						GetComponent<RectTransform>().transform.localScale.y + 0.002f);
				}
			}

			if (Input.GetKey(KeyCode.DownArrow))	// Pārbauda, vai ir nospiests "↓"
			{
				// Samazina pedejo vilkto objektu pa Y ass virzienu, ja tā skalas y vērtība ir lielāka par 0.10
				if (objektuSkripts.pedejaisVilktais.
					GetComponent<RectTransform>().transform.localScale.y >= 0.10f)
				{
					objektuSkripts.pedejaisVilktais.
						GetComponent<RectTransform>().transform.localScale =
						new Vector2(objektuSkripts.pedejaisVilktais.
						GetComponent<RectTransform>().transform.localScale.x,
						objektuSkripts.pedejaisVilktais.
						GetComponent<RectTransform>().transform.localScale.y - 0.002f);
				}
			}


			if (Input.GetKey(KeyCode.LeftArrow))	// Pārbauda, vai ir nospiests "←"
            {
				// Samazina pedejo vilkto objektu pa X ass virzienu, ja tā skalas x vērtība ir lielāka par 0.10
                if (objektuSkripts.pedejaisVilktais.
                    GetComponent<RectTransform>().transform.localScale.x >= 0.10f)
                {
                    objektuSkripts.pedejaisVilktais.
                        GetComponent<RectTransform>().transform.localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.
                        GetComponent<RectTransform>().transform.localScale.x - 0.002f,
                        objektuSkripts.pedejaisVilktais.
                        GetComponent<RectTransform>().transform.localScale.y);
                }
            }

			if (Input.GetKey(KeyCode.RightArrow))	// Pārbauda, vai ir nospiests "→"
            {
				// Palielina pedejo vilkto objektu pa X ass virzienu, ja tā skalas x vērtība ir mazāka par 1
                if (objektuSkripts.pedejaisVilktais.
                    GetComponent<RectTransform>().transform.localScale.x <= 1f)
                {
                    objektuSkripts.pedejaisVilktais.
                        GetComponent<RectTransform>().transform.localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.
                        GetComponent<RectTransform>().transform.localScale.x + 0.002f,
                        objektuSkripts.pedejaisVilktais.
                        GetComponent<RectTransform>().transform.localScale.y);
                }
            }
        }
	}
}
