using UnityEngine;
using System.Collections;
using System;
using UnityEditor;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor(typeof(PickUp))]
public class PickUpEditor : Editor
{
	// variables for the icons to be shown in the Inspector
	// for this custom Inspector view
	public Texture iconHealth;
	public Texture iconKey;
	public Texture iconStar;

	// variables referencing the sprite images
	// to which the selected GameObject will display
	// corresponding to pickup type chosen
	public Sprite spriteHealth100;
	public Sprite spriteKey100;
	public Sprite spriteStar100;

	// our copy of the 'type' value from the component being edited
	UnityEditor.SerializedProperty pickUpType;

	//
	private Sprite sprite;
	private PickUp pickupObject;

	/*---------------------------------------------------
	 * load the Inspector icons, and GameObject Sprites when item selected in Hierarchy
	 *
	 * get copy of 'target' object details into 'pickupObject'
	 *
	 * retrieve current value of 'type'
	 */
	void OnEnable ()
	{
		iconHealth = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_heart_32.png", typeof(Texture)) as Texture;
		iconKey = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_key_green_32.png", typeof(Texture)) as Texture;
		iconStar = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_star_32.png", typeof(Texture)) as Texture;
		
		spriteHealth100 = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/healthheart.png", typeof(Sprite)) as Sprite;
		spriteKey100 = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_key_green_100.png", typeof(Sprite)) as Sprite;
		spriteStar100 = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/star.png", typeof(Sprite)) as Sprite;
		
		pickupObject = (PickUp)target;
		pickUpType = serializedObject.FindProperty ("type");
	}
	
	/*---------------------------------------------------
	 * each frame when object details are being displayed in the Inspector:
	 *
	 * offer a drop down list
	 *
	 * base on the item selected in the list
	 * call the appropriate method (i.e. the one corresponding to the type selected)
	 *
	 * finally, store back any changes to GameObject 'ApplyModifiedProperties()'
	 */
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
	
	/*---------------------------------------------------
	 * display heart icons and "HEATH" in Inspector
	 *
	 * and set the GameObejct's sprite to the heart sprite
	 */
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
	
	/*---------------------------------------------------
	 * display Key icons and "KET" in Inspector
	 *
	 * and set the GameObejct's sprite to the key sprite
	 */
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
	
	/*---------------------------------------------------
	 * display Star icons and "STAR" in Inspector
	 *
	 * and set the GameObejct's sprite to the star sprite
	 */
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
	
	/*---------------------------------------------------
	 * create a string array of the different values of enum PickUpType
	 *
	 * so we can use this array to display a drop down menu to user
	 * in inspector, for them to change the 'type' of the Pickup
	 */
	private string[] TypesToStringArray()
	{
		var pickupValues = (PickUp.PickUpType[])Enum.GetValues(typeof(PickUp.PickUpType));
		
		List<string> stringList = new List<string>();
		
		foreach(PickUp.PickUpType pickupValue in pickupValues){
			string stringName = pickupValue.ToString();
			stringList.Add(stringName);
		}
		
		return stringList.ToArray();
	}
}
