using UnityEngine;
using System.Collections;
using System;
 
public class AverageDistance2 : MonoBehaviour
{
	private GameObject[] sphereArray;
	private GameObject[] sphereGOArrayCache;

	private void Start(){
		sphereGOArrayCache = GameObject.FindGameObjectsWithTag("Respawn");
	}

	private void Update(){
		// method1 - basic
		Profiler.BeginSample("TESTING_method1");
		sphereArray = GameObject.FindGameObjectsWithTag("Respawn");
		for(int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceBasic(i);
		}
		Profiler.EndSample();		

		// method2 - use cached sphere ('Respawn' array)
		Profiler.BeginSample("TESTING_method2");
		sphereArray = sphereGOArrayCache;
		for(int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceBasic(i);
		}
		Profiler.EndSample();		
	}

	// basic 
	private void HalfDistanceBasic(int i){
		Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 pos1 = playerTransform.position;
		Transform sphereGOTransform = sphereArray[i].transform;
		Vector3 pos2 = sphereGOTransform.position;

		float distance = Vector3.Distance(pos1, pos2);
		
		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
	}
}