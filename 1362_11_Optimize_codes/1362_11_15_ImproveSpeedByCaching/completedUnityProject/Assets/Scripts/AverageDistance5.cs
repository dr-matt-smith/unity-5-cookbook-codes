using UnityEngine;
using System.Collections;
using System;
 
public class AverageDistance5 : MonoBehaviour
{
	private GameObject[] sphereArray;
	private GameObject[] sphereGOArrayCache;

	private Transform playerTransformCache;
	private Vector3 pos1Cache;
	private SimpleMath mathObjectCache;

	private void Start(){
		sphereGOArrayCache = GameObject.FindGameObjectsWithTag("Respawn");
		playerTransformCache = GameObject.FindGameObjectWithTag("Player").transform;
		pos1Cache = playerTransformCache.position;
		mathObjectCache = GetComponent<SimpleMath>();
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
		sphereArray = GameObject.FindGameObjectsWithTag("Respawn");
		for(int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceCachePlayerTransform(i);
		}
		Profiler.EndSample();		
		
		// method4 - use cached playerTransform.position
		Profiler.BeginSample("TESTING_method4");
		sphereArray = GameObject.FindGameObjectsWithTag("Respawn");
		for(int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceCachePlayer1Position(i);
		}
		Profiler.EndSample();		
		
		// method5 - use cached math component
		Profiler.BeginSample("TESTING_method5");
		sphereArray = GameObject.FindGameObjectsWithTag("Respawn");
		for(int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceCacheMathComponent(i);
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
		Transform sphereGOTransform = sphereGOArrayCache[i].transform;
		Vector3 pos2 = sphereGOTransform.position;

		float distance = Vector3.Distance(pos1, pos2);
		
		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
	}
		
	// player position cached
	private void HalfDistanceCachePlayer1Position(int i){
		Vector3 pos1 = pos1Cache;
		Transform sphereGOTransform = sphereGOArrayCache[i].transform;
		Vector3 pos2 = sphereGOTransform.position;

		float distance = Vector3.Distance(pos1, pos2);

		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
	}
	
	// math Component cache
	private void HalfDistanceCacheMathComponent(int i){
		Vector3 pos1 = pos1Cache;
		Transform sphereGOTransform = sphereGOArrayCache[i].transform;
		Vector3 pos2 = sphereGOTransform.position;

		float distance = Vector3.Distance(pos1, pos2);

		SimpleMath mathObject = mathObjectCache;
		float halfDistance = mathObject.Halve(distance);
	}
}