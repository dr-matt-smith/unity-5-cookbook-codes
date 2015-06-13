using UnityEngine;
using System.Collections;
 
public class SphereBuilder : MonoBehaviour
{
	public const int NUM_SPHERES = 1000;
	public GameObject spherePrefab;

	void Awake(){
		ArrayList randomPositions = BuildVector3ArrayList(NUM_SPHERES);
		for(int i=0; i < NUM_SPHERES; i++){
			Vector3 pos = (Vector3)randomPositions[i];
			Instantiate(spherePrefab, pos, Quaternion.identity);
		}
	}

	public ArrayList BuildVector3ArrayList(int numPositions){
		ArrayList positionArrayList = new ArrayList();
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