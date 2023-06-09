﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 	//Jāieimportē, lai varētu lietot visus interfeisus

public class DragDropSkripts : MonoBehaviour, 
    IPointerDownHandler, IBeginDragHandler, 
    IDragHandler, IEndDragHandler {
	public Objekti objektuSkripts;	//Uzglabā norādi uz Objekti skriptu
	private CanvasGroup kanvasGrupa;	//Velkamam objektam piestiprinātā CanvasGoup komponente
	private RectTransform velkObjRectTransf;	//Objekta atrašanās vieta, kurš tiek pārvietots

    void Start()
    {
		kanvasGrupa = GetComponent<CanvasGroup>();	//Piekļūst objektam piestiprinātajai CanvasGroup komponentei
		velkObjRectTransf = GetComponent<RectTransform>();	//Piekļūst objeta rectTransform komponentei
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
		Debug.Log("Uzklikšķināts uz velkama objekta!");
		objektuSkripts.pedejaisVilktais = null;		// Notiek vilktā objekta norādes atiestatīšana
		kanvasGrupa.alpha = 0.6f;		// Iestatām vilktā objekta alfa vērtību, lai tas kļūtu caurspīdīgs
		kanvasGrupa.blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
		velkObjRectTransf.anchoredPosition +=
			eventData.delta / objektuSkripts.kanva.scaleFactor; 	// Pārvietojam vilkto objektu, pamatojoties uz peles kustības datiem
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        objektuSkripts.pedejaisVilktais = eventData.pointerDrag;	// Saglabājam pedējo vilkto objektu
		kanvasGrupa.alpha = 1f;		// Atjaunojam vilkāmā objekta CanvasGroup alfa vērtību

		if(objektuSkripts.vaiIstajaVieta == false) {	// Pārbaudām, vai objekts ir atpakaļ savā vietā
			kanvasGrupa.blocksRaycasts = true;		// Iestatām vilktā objekta CanvasGroup "blocksRaycasts" vērtību

        } else {
			objektuSkripts.pedejaisVilktais = null;		// Notiek vilktā objekta norādes atiestatīšana
        }

		objektuSkripts.vaiIstajaVieta = false;		// Atjaunojam objekta "vaiIstajaVieta" vērtību
    }

	public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
