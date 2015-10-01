using UnityEngine;
using System.Collections;
using System;

/*---------------------------------------------------------
 * class to run and profile different methods
 * so each can be compared with the Unity Profiler
 */
public class AverageDistance6 : MonoBehaviour
{
    // stored array of Sphere positions
	private Vector3[] spherePositionArrayCache = new Vector3[SphereBuilder.NUM_SPHERES];

	// stored reference to SimpleMath object
	private SimpleMath mathObjectCache;

	// stored position1
	private Vector3 pos1Cache;

	// stored reference to Transform component of Player GameObject
	private Transform playerTransformCache;

	   // stored array of references to all the Transfoms of all the Spheres
	private Transform[] sphereTransformArrayCache;

    /*-------------------------------------------------
     * cache reference to SimpleMath siblining component
     */
	private void Awake()
	{
		mathObjectCache = GetComponent<SimpleMath>();
	}

    /*-------------------------------------------------
     * get array of references to GameObjects tagged 'Respawn'
     *
     * stored the positions and Transform for all these objects
     * in 'sphereTransformArrayCache' and 'spherePositionArrayCache'
     *
     * cache reference to Player's Transfoom
     * and also cache refernce to Vector3 Player's position
     */
	private void Start()
	{
		GameObject[] sphereGOArray = GameObject.FindGameObjectsWithTag("Respawn");
		sphereTransformArrayCache = new Transform[SphereBuilder.NUM_SPHERES];
		for (int i=0; i < SphereBuilder.NUM_SPHERES; i++){
			sphereTransformArrayCache[i] = sphereGOArray[i].transform;
			spherePositionArrayCache[i] = sphereGOArray[i].transform.position;
		}
		
		playerTransformCache = GameObject.FindGameObjectWithTag("Player").transform;
		pos1Cache = playerTransformCache.position;
	}

    /*-------------------------------------------------
     * each frame, try each of the different methods
     * starting and ending the Profiler before and after each technique
     * tagging the prolfies with the technique names "_method1" "_method2" etc.
     */
	private void Update()
	{
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


    /*------------------------------------------------
     * each of the methods below uses more and more efficient ways
     * to calculate half the distance from Player to each sphere
     */

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