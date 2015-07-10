using UnityEngine;
using System.Collections;
using System;
 
public class AverageDistance6 : MonoBehaviour
{
	private Vector3[] spherePositionArrayCache = new Vector3[SphereBuilder.NUM_SPHERES];
	private SimpleMath mathObjectCache;
	private Vector3 pos1Cache;
	private Transform playerTransformCache;
	private Transform[] sphereTransformArrayCache;

	private void Awake(){
		mathObjectCache = GetComponent<SimpleMath>();
	}
	
	private void Start(){
		GameObject[] sphereGOArray = GameObject.FindGameObjectsWithTag("Respawn");
		sphereTransformArrayCache = new Transform[SphereBuilder.NUM_SPHERES];
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			sphereTransformArrayCache[i] = sphereGOArray[i].transform;
			spherePositionArrayCache[i] = sphereGOArray[i].transform.position;
		}
		
		playerTransformCache = GameObject.FindGameObjectWithTag("Player").transform;
		pos1Cache = playerTransformCache.position;
	}

	private void Update(){
		// method1 - basic
		Profiler.BeginSample("TESTING_method1");
		GameObject[] sphereArray = GameObject.FindGameObjectsWithTag("Respawn");
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceBasic(sphereArray[i].transform);
		}
		Profiler.EndSample();		
		
		// method2 - use cached sphere ('Respawn' array)
		Profiler.BeginSample("TESTING_method2");
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceBasic(sphereTransformArrayCache[i]);
		}
		Profiler.EndSample();		
		
		// method3 - use cached playerTransform
		Profiler.BeginSample("TESTING_method3");
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceCachePlayerTransform(sphereTransformArrayCache[i]);
		}
		Profiler.EndSample();	
		
		// method4 - use cached playerTransform.position
		Profiler.BeginSample("TESTING_method4");
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceCachePlayer1Position(sphereTransformArrayCache[i]);
		}
		Profiler.EndSample();			
		
		// method5 - use cached math component
		Profiler.BeginSample("TESTING_method5");
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceCacheMathComponent(sphereTransformArrayCache[i]);
		}

		// method6 - use cached array of sphere positions
		Profiler.BeginSample("TESTING_method6");
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			HalfDistanceCacheSpherePositions(sphereTransformArrayCache[i], spherePositionArrayCache[i]);
		}
		Profiler.EndSample();		
	}

	// basic 
	private void HalfDistanceBasic(Transform sphereGOTransform){
		Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 pos1 = playerTransform.position;
		Vector3 pos2 = sphereGOTransform.position;
		
		float distance = Vector3.Distance(pos1, pos2);
		
		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
	}
	
	// playerTransform cached
	private void HalfDistanceCachePlayerTransform(Transform sphereGOTransform){
		Vector3 pos1 = playerTransformCache.position;
		Vector3 pos2 = sphereGOTransform.position;
		float distance = Vector3.Distance(pos1, pos2);
		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
	}
	
	// player position cached
	private void HalfDistanceCachePlayer1Position(Transform sphereGOTransform){
		Vector3 pos1 = pos1Cache;
		Vector3 pos2 = sphereGOTransform.position;
		float distance = Vector3.Distance(pos1, pos2);
		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
	}
	
	// math Component cache
	private void HalfDistanceCacheMathComponent(Transform sphereGOTransform){
		Vector3 pos1 = pos1Cache;
		Vector3 pos2 = sphereGOTransform.position;
		float distance = Vector3.Distance(pos1, pos2);
		SimpleMath mathObject = mathObjectCache;
		float halfDistance = mathObject.Halve(distance);
	}
	
	// sphere position cache
	private void HalfDistanceCacheSpherePositions(Transform sphereGOTransform, Vector3 pos2){
		Vector3 pos1 = pos1Cache;
		float distance = Vector3.Distance(pos1, pos2);
		SimpleMath mathObject = mathObjectCache;
		float halfDistance = mathObject.Halve(distance);
	}

}