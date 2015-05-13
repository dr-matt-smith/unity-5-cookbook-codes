using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MoveToFront : MonoBehaviour, IPointerDownHandler {
	RectTransform panelRectTransform;

	void Start(){
		panelRectTransform = GetComponent<RectTransform>();
	}
	
	public void OnPointerDown (PointerEventData data) {
		panelRectTransform.SetAsLastSibling ();
	}
}