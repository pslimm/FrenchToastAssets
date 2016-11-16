using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PuzzlePieceSlot : MonoBehaviour, IDropHandler 
{
    public string tag;
	public GameObject item
	{
		get
		{
			if (transform.childCount > 1)
			{
                Debug.Log("Dropping");
				return transform.GetChild(1).gameObject;
			}

			return null;
		}
	}

	#region IDropHandler implementation

	public void OnDrop(PointerEventData eventData)
	{
		if (!item)
		{
			PuzzlePieceDrag.itemBeingDragged.transform.SetParent(transform);
		}
	}

	#endregion
}
