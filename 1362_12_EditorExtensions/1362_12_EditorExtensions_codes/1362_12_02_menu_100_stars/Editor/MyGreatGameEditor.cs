using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class MyGreatGameEditor : MonoBehaviour
{
	// max/min range for X and Y values
	const float X_MAX = 10f;
	const float Y_MAX = 10f;

	// reference to prefab object, of which we are going to make 100 instances in Scene
	static GameObject starPrefab;

	/*---------------------------------------------------------
	 * display menu "My-Great-Game"
	 * with one menu item "Make 100 stars"
	 * and when that menu item is chosen the next method will execute - i.e. PlacePrefabs()
	 */
	[MenuItem("My-Great-Game/Make 100 stars")]
	static void PlacePrefabs()
	{
		// path to our prefab object
		string assetPath = "Assets/Prefabs/prefab_star.prefab";

		// load the prefab into 'starPrefab;
		starPrefab = (GameObject)AssetDatabase.LoadMainAssetAtPath(assetPath);

		// loop 100 times, creating an instance in a random location each time
		int total = 100;
		for(int i = 0; i < total; i++){
			CreateRandomInstance();
		}
	}
	
	/*---------------------------------------------------------
	 * create a randomly placed instance of 'starPrefab'
	 * in the range (-X_MAX, -Y_MAX) - (X_MAX, Y_MAX)
	 */
	static void CreateRandomInstance()
	{
		float x = UnityEngine.Random.Range(-X_MAX, X_MAX);
		float y = UnityEngine.Random.Range(-Y_MAX, Y_MAX);
		float z = 0;
		Vector3 randomPosition = new Vector3(x,y,z);
		
		Instantiate(starPrefab, randomPosition, Quaternion.identity);
	}
}
