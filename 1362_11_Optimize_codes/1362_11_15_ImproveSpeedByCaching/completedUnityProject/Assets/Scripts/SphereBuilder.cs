using UnityEngine;
using System.Collections;

using System.Collections.Generic;
 
public class SphereBuilder : MonoBehaviour
{
	public const int NUM_SPHERES = 1000;
	public GameObject spherePrefab;

	void Awake(){
		List<Vector3> randomPositions = BuildVector3Collection(NUM_SPHERES);
		for(int i=0; i < NUM_SPHERES; i++){
			Vector3 pos = randomPositions[i];
			Instantiate(spherePrefab, pos, Quaternion.identity);
		}
	}

	public List<Vector3> BuildVector3Collection(int numPositions){
		List<Vector3> positionArrayList = new List<Vector3>();
		for(int i=0; i < numPositions; i++) {
			float x = Random.Range(-100, 100);
			float y = Random.Range(1, 100);
			float z = Random.Range(-100, 100);
			Vector3 pos = new Vector3(x,y,z);
			positionArrayList.Add (pos);
		}
		
		return positionArrayList;
	}
}