using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektuTransformacijas : MonoBehaviour {
	public Objekti objektuSkripts;

	void Update()
	{
		if (objektuSkripts.pedejaisVilktais != null)
		{
			if (Input.GetKey(KeyCode.Z))
			{
				objektuSkripts.pedejaisVilktais.
				GetComponent<RectTransform>().Rotate(0, 0, Time.deltaTime * 30f);
			}

			if (Input.GetKey(KeyCode.X))
			{
				objektuSkripts.pedejaisVilktais.
				GetComponent<RectTransform>().Rotate(0, 0, -Time.deltaTime * 30f);
			}

			if (Input.GetKey(KeyCode.UpArrow))
			{
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

			if (Input.GetKey(KeyCode.DownArrow))
			{
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


            if (Input.GetKey(KeyCode.LeftArrow))
            {
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

            if (Input.GetKey(KeyCode.RightArrow))
            {
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
