using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MoveToFront : MonoBehaviour, IPointerDownHandler
{
	// reference to parent GameObject' rect transform
	RectTransform panelRectTransform;

	//---------------------
	void Start()
	{
		panelRectTransform = GetComponent<RectTransform>();
	}

	//---------------------
	// move parent GameObject to be last in list of sibling UI GameObjects
	// since Unity 'paints' UI from top of list ot bottom of list, the item last in list
	// is dispayed on TOP of all the others
	//
	// so we have MOVED this parent GameObject to the 'front' of all its siblings on screen
	public void OnPointerDown (PointerEventData data)
	{
		panelRectTransform.SetAsLastSibling ();
	}
}