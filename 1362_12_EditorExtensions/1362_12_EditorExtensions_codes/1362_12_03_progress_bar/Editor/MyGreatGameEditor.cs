using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class MyGreatGameEditor : MonoBehaviour
{
	const float X_MAX = 10f;
	const float Y_MAX = 10f;
	
	static GameObject starPrefab;
	
	[MenuItem("My-Great-Game/Make 100 stars")]
	static void PlacePrefabs()
	{
		string assetPath = "Assets/Prefabs/prefab_star.prefab";
		starPrefab = (GameObject)AssetDatabase.LoadMainAssetAtPath(assetPath);
		
		int total = 100;
		for(int i = 0; i < total; i++){
			CreateRandomInstance();

			//-------------------------------------------
			// display a PROGRESS BAR popup window
			// where "i" is our percentage progress completed
			//
			// e.g. if i=20, then we display "25%" and a bar that is 0.25 completed
			//-------------------------------------------
			EditorUtility.DisplayProgressBar("Creating your starfield", i + "%", i/100f);
		}
		
		//-------------------------------------------
		// remove the PROGRESS BAR popup window
		// (since we've finished our processing
		//-------------------------------------------
		EditorUtility.ClearProgressBar();
	}

	static void CreateRandomInstance()
	{
		float x = UnityEngine.Random.Range(-X_MAX, X_MAX);
		float y = UnityEngine.Random.Range(-Y_MAX, Y_MAX);
		float z = 0;
		Vector3 randomPosition = new Vector3(x,y,z);
		
		Instantiate(starPrefab, randomPosition, Quaternion.identity);
	}
}
