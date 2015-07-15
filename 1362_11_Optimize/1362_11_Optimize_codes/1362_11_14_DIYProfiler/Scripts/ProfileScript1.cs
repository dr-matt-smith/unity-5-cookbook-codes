// file: ProfileScript1.cs
using UnityEngine;
using System.Collections;

using System;

 
public class ProfileScript1 : MonoBehaviour
{
	private int ITERATIONS = 2;
/*
	private void Start(){
		ArrayList randomPositions = RandomPositionManager.BuildVector3ArrayList(SIZE);
		for(int i=0; i < 2000; i++){
			Profile.StartProfile("ArrayListBuildSearch");
			FindClosestPosition(randomPositions);
			Profile.EndProfile("ArrayListBuildSearch");
		}
	}
 
	private void FindClosestPosition(ArrayList positions){
		float minDistance = 1000;
		for(int i=0; i < SIZE; i++) {
			Vector3 pos = (Vector3)positions[i];
			Vector3 cameraPosition = transform.position;
			float distance = Vector3.Distance(cameraPosition, pos);
			if( distance < minDistance)
				minDistance = distance;
		}
	}
*/
	
	public Transform playerTransformCache;
	private SimpleMath mathObjectCache;
	private Transform cameraTransformCache;
	
	private void Awake(){
		// cache the object references
		mathObjectCache = GetComponent<SimpleMath>();
		cameraTransformCache = transform;
	}
	
	
	
	private void Start(){
		for(int i=0; i < ITERATIONS; i++){
			FindDistanceMethod4();
		}
	}
		
	private void OnApplicationQuit()
	{
		Profile.PrintResults();
	}
	
	//------ method 1 --------
	
	private void FindDistanceMethod1(){
		Profile.StartProfile("Method-1");
		Vector3 pos1 = transform.position;
		Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 pos2 = playerTransform.position;
		float distance = Vector3.Distance(pos1, pos2);
		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
		Profile.EndProfile("Method-1");
	}
	
	//------ method 2 --------
	

	private void FindDistanceMethod2(){
		Profile.StartProfile("Method-2");
		Vector3 pos1 = transform.position;
		Vector3 pos2 = playerTransformCache.position;
		float distance = Vector3.Distance(pos1, pos2);
		SimpleMath mathObject = GetComponent<SimpleMath>();
		float halfDistance = mathObject.Halve(distance);
		Profile.EndProfile("Method-2");
	}
	
	// ----- method 3 ----------
	
	private void FindDistanceMethod3(){
		Profile.StartProfile("Method-3");
		print ( DateTime.UtcNow );
		transform.Translate(1,1,1);
		print ( DateTime.UtcNow );
/*		
		Vector3 pos1 = transform.position;
		Vector3 pos2 = playerTransformCache.position;
		float distance = Vector3.Distance(pos1, pos2);
		float halfDistance = mathObjectCache.Halve(distance);
*/
		Profile.EndProfile("Method-3");
	}

	// ----- method 4 ----------
	private void FindDistanceMethod4(){
		Profile.StartProfile("Method-4");

		print ( DateTime.UtcNow );
		cameraTransformCache.Translate(1,1,1);
		print ( DateTime.UtcNow );
/*
		Vector3 pos1 = cameraTransformCache.position;
		Vector3 pos2 = playerTransformCache.position;
		float distance = Vector3.Distance(pos1, pos2);
		float halfDistance = mathObjectCache.Halve(distance);
*/
		Profile.EndProfile("Method-4");
	}

}