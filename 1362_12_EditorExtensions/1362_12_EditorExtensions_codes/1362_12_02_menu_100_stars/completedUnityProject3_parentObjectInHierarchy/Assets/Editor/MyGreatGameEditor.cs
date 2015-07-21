using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class MyGreatGameEditor : MonoBehaviour {
	const float X_MAX = 10f;
	const float Y_MAX = 10f;
	
	static GameObject starContainerGO;
	static GameObject starPrefab;
	
	[MenuItem("My-Great-Game/Make 100 stars")]
	static void PlacePrefabs(){
		CreateStarContainerGO();

		string assetPath = "Assets/Prefabs/prefab_star.prefab";
		starPrefab = (GameObject)AssetDatabase.LoadMainAssetAtPath(assetPath);
		
		int total = 100;
		for(int i = 0; i < total; i++){
			CreateRandomInstance();
			EditorUtility.DisplayProgressBar("Creating your starfield", i + "%", i/100f);
		}
		
		EditorUtility.ClearProgressBar();
	}

	static void CreateStarContainerGO()
	{
		string containerName = "Star-container";
		
		// find existing object
		starContainerGO = GameObject.Find(containerName);
		
		// if existing object, then delete it (get rid of any previous starfield)
		if (null != starContainerGO) DestroyImmediate(starContainerGO);
		
		// now create new empty one
		Debug.Log ("creating new container ...");

		starContainerGO = new GameObject(containerName);
	}

	static void CreateRandomInstance() {
		float x = UnityEngine.Random.Range(-X_MAX, X_MAX);
		float y = UnityEngine.Random.Range(-Y_MAX, Y_MAX);
		float z = 0;
		Vector3 randomPosition = new Vector3(x,y,z);
		
		GameObject newStarGO = (GameObject)Instantiate(starPrefab, randomPosition, Quaternion.identity);
		newStarGO.transform.parent = starContainerGO.transform;
	}

}
