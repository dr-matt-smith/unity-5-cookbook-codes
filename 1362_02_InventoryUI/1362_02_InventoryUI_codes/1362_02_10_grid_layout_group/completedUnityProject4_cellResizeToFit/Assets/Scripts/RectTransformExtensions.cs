using UnityEngine;
using System;
using System.Collections;

public static class RectTransformExtensions
{
	public static void SetSize(this RectTransform trans, Vector2 newSize) {
		Vector2 oldSize = trans.rect.size;
		Vector2 deltaSize = newSize - oldSize;
		trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
	}
	
	public static void SetWidth(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(newSize, trans.rect.size.y));
	}
	
	public static void SetHeight(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(trans.rect.size.x, newSize));
	}	
}
