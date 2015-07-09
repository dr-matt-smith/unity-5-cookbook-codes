using UnityEngine;
using System.Collections;
using System;
 
public class AverageDistance3 : MonoBehaviour
{
	private GameObject[] sphereArray;
	private GameObject[] sphereGOArrayCache;
	private Transform playerTransformCache;

	private void Start(){
		sphereGOArrayCache = GameObject.FindGameObjectsWithTag("Respawn");
		playerTransformCache = GameObject.FindGameObjectWithTag("Player").transform;
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

		// method3 - use cached playerTransform
		Profiler.BeginSample("TESTING_method3");
		sphereArray = sphereGOArrayCache;
		for(int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceCachePlayerTransform(i);
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
	
	// playerTransform cached
	private void HalfDistanceCachePlayerTransform(int i){
		Vector3 pos1 = playerTransformCache.position;
		Transform sphereGOTransform = sphereArray[i].transform;
		Vector3 pos2 = sphereGOTransform.position;

		float distance = Vector3.Distance(pos1, pos2);
		
		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
	}
}