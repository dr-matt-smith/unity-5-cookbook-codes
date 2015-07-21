using UnityEngine;
using System.Collections;
using System;
using UnityEditor;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor(typeof(PickUp))]
public class PickUpEditor : Editor
{
	public Texture iconHealth;
	public Texture iconKey;
	public Texture iconStar;
	
	public Sprite spriteHealth100;
	public Sprite spriteKey100;
	public Sprite spriteStar100;
	
	UnityEditor.SerializedProperty pickUpType;
	
	private Sprite sprite;
	private PickUp pickupObject;
	
	void OnEnable () {
		iconHealth = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_heart_32.png", typeof(Texture)) as Texture;
		iconKey = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_key_green_32.png", typeof(Texture)) as Texture;
		iconStar = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_star_32.png", typeof(Texture)) as Texture;
		
		spriteHealth100 = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/healthheart.png", typeof(Sprite)) as Sprite;
		spriteKey100 = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_key_green_100.png", typeof(Sprite)) as Sprite;
		spriteStar100 = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/star.png", typeof(Sprite)) as Sprite;
		
		pickupObject = (PickUp)target;
		pickUpType = serializedObject.FindProperty ("type");
	}
	
	
	public override void OnInspectorGUI()
	{
		serializedObject.Update ();
		
		string[] pickUpCategories = TypesToStringArray();
		pickUpType.enumValueIndex = EditorGUILayout.Popup("PickUp TYPE: ", pickUpType.enumValueIndex, pickUpCategories); 
		
		PickUp.PickUpType type = (PickUp.PickUpType)pickUpType.enumValueIndex;
		switch(type)
		{
		case PickUp.PickUpType.Health:
			InspectorGUI_HEALTH();
			break;
			
		case PickUp.PickUpType.Key:
			InspectorGUI_KEY();
			break;
			
		case PickUp.PickUpType.Star:
		default:
			InspectorGUI_STAR();
			break;
		}
		
		serializedObject.ApplyModifiedProperties ();
	}
	
	private void InspectorGUI_HEALTH()
	{
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label(iconHealth);
		GUILayout.Label("HEALTH");
		GUILayout.Label(iconHealth);
		GUILayout.Label("HEALTH");
		GUILayout.Label(iconHealth);
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		
		pickupObject.SetSprite(spriteHealth100);
	}
	
	private void InspectorGUI_KEY()
	{
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label(iconKey);
		GUILayout.Label("KEY");
		GUILayout.Label(iconKey);
		GUILayout.Label("KEY");
		GUILayout.Label(iconKey);
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		
		pickupObject.SetSprite(spriteKey100);
	}
	
	private void InspectorGUI_STAR()
	{
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label(iconStar);
		GUILayout.Label("STAR");
		GUILayout.Label(iconStar);
		GUILayout.Label("STAR");
		GUILayout.Label(iconStar);
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		
		pickupObject.SetSprite(spriteStar100);
	}
	
	private string[] TypesToStringArray(){
		var pickupValues = (PickUp.PickUpType[])Enum.GetValues(typeof(PickUp.PickUpType));
		
		List<string> stringList = new List<string>();
		
		foreach(PickUp.PickUpType pickupValue in pickupValues){
			string stringName = pickupValue.ToString();
			stringList.Add(stringName);
		}
		
		return stringList.ToArray();
	}
}
