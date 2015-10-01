using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectBuilderScript))]
public class ObjectBuilderEditor : Editor
{
	// icons to show in Inspector
	private Texture iconStar;
	private Texture iconHeart;
	private Texture iconKey;

	// 3 prefabs - corresponding to the objects we wish to create
	private GameObject prefabHeart;
	private GameObject prefabStar;
	private GameObject prefabKey;

	/*--------------------------------------------------------
	 * when the object is first enabled/selected
	 * load the icons and prefabs into variables
	 */
	void OnEnable ()
	{
		iconStar = Resources.LoadAssetAtPath("Assets/EditorSprites/icon_star_32.png", typeof(Texture)) as Texture;
		iconHeart = Resources.LoadAssetAtPath("Assets/EditorSprites/icon_heart_32.png", typeof(Texture)) as Texture;
		iconKey = Resources.LoadAssetAtPath("Assets/EditorSprites/icon_key_green_32.png", typeof(Texture)) as Texture;
		
		prefabStar = Resources.LoadAssetAtPath("Assets/Prefabs/star.prefab", typeof(GameObject)) as GameObject;
		prefabHeart = Resources.LoadAssetAtPath("Assets/Prefabs/heart.prefab", typeof(GameObject)) as GameObject;
		prefabKey = Resources.LoadAssetAtPath("Assets/Prefabs/key.prefab", typeof(GameObject)) as GameObject;
	}
	
	/*--------------------------------------------------------
	 * each frame when object's properties to be displayed in the Inspector
	 *
	 * offer 3 buttons to the user
	 *
	 * when clicked, call method AddObjectToScene() with the prefab corresponding to the button
	 *
	 */
	public override void OnInspectorGUI()
	{
		// 'myScript' is a reference to the object whose properties are being displayed
		// in the Inspector
		// (the one that shows the 'cross hairs' so we know where new pickup GameObject will be created)
		ObjectBuilderScript myScript = (ObjectBuilderScript)target;
		
		GUILayout.Label("");
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label("Click button to create instance of prefab");
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.Label("");
		
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if(GUILayout.Button(iconStar))
			myScript.AddObjectToScene(prefabStar);

		GUILayout.FlexibleSpace();
		if(GUILayout.Button(iconHeart))
			myScript.AddObjectToScene(prefabHeart);

		GUILayout.FlexibleSpace();
		if(GUILayout.Button(iconKey))
			myScript.AddObjectToScene(prefabKey);

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		
	}
}
