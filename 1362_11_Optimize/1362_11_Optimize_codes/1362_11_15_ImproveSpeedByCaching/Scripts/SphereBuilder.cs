using UnityEngine;
using System.Collections;

using System.Collections.Generic;

/*---------------------------------------------------
 * create 1000 sphere GameObjects at random locations in the scene
 */
public class SphereBuilder : MonoBehaviour
{
	// number of spheres to create
	public const int NUM_SPHERES = 1000;

	// reference to prefab of sphere to be cloned
	public GameObject spherePrefab;

	/*-----------------------------------------------------------------
	 * build a list of 1000 Vector3 random positions
	 * then loop through and instantiate a clone of the prefab at each location
	 */
	void Awake()
	{
		List<Vector3> randomPositions = BuildVector3Collection(NUM_SPHERES);

		for(int i=0; i < NUM_SPHERES; i++){
			Vector3 pos = randomPositions[i];
			Instantiate(spherePrefab, pos, Quaternion.identity);
		}
	}

	/*-----------------------------------------------------------------
	 * build a list of 1000 Vector3 random positions
	 *
	 * for the given number of positions, loop to create and add to List<> 'positionArrayList'
	 * random Vector3
	 * in range (-100..+100, 1..100, -100..+100)
	 */
	public List<Vector3> BuildVector3Collection(int numPositions)
	{
		List<Vector3> positionArrayList = new List<Vector3>();

		for (int i=0; i < numPositions; i++) {
			float x = Random.Range(-100, 100);
			float y = Random.Range(1, 100);
			float z = Random.Range(-100, 100);
			Vector3 pos = new Vector3(x,y,z);
			positionArrayList.Add (pos);
		}
		
		return positionArrayList;
	}
}