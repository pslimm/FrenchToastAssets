﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PuzzlePieceDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;
    public string matchTag;

	#region IBeginDragHandler implementation

	public void OnBeginDrag(PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation
	
	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged = null;
		transform.position = startPosition;

		GetComponent<CanvasGroup>().blocksRaycasts = true;

		if (transform.parent != startParent)
			transform.position = startPosition;
	}
	
	#endregion
}
