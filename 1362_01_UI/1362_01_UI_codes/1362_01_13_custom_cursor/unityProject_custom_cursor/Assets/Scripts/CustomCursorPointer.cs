using UnityEngine;
using System.Collections;

public class CustomCursorPointer : MonoBehaviour {
	public Texture2D cursorTexture2D;

	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	public void OnMouseEnter() {
		SetCustomCursor(cursorTexture2D);
	}

	public void OnMouseExit() {
		SetCustomCursor(null);
	}
	
	private void SetCustomCursor(Texture2D curText){
		Cursor.SetCursor(curText, hotSpot, cursorMode);
	}
}
