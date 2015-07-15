using UnityEngine;
using System.Collections;
using System;
 
public class AverageDistance2 : MonoBehaviour
{
	private Transform[] sphereTransformArrayCache;

	private void Start(){
		GameObject[] sphereGOArray = GameObject.FindGameObjectsWithTag("Respawn");
		sphereTransformArrayCache = new Transform[SphereBuilder.NUM_SPHERES];
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			sphereTransformArrayCache[i] = sphereGOArray[i].transform;
		}
	}

	void Update(){
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
}