// file: ProfileScript1.cs
using UnityEngine;
using System.Collections;

using System;

 
public class ProfileScript1 : MonoBehaviour
{
	// number of times to perform operation
	private int ITERATIONS = 2;

	// reference to Transform component of Player
	public Transform playerTransformCache;

	// reference to object instance of SimpleMath class
	private SimpleMath mathObjectCache;

	// reference to Transform of MainCamera
	private Transform cameraTransformCache;
	
	/*-----------------------------------------
	 * find and store refernces to camera Transform and to SimpleMath sibling object
	 */
	private void Awake()
	{
		// cache the object references
		mathObjectCache = GetComponent<SimpleMath>();
		cameraTransformCache = transform;
	}

	/*--------------------------------------------------
	 * call method to be profiled ITERATIONS number of times
	 */
	private void Start()
	{
		for(int i=0; i < ITERATIONS; i++){
			//FindDistanceMethod1();
			//FindDistanceMethod2();
			//FindDistanceMethod3();
			FindDistanceMethod4();
		}
	}

	/*-------------------------------------------
	 * when scene/application terminated
	 * output profile resuls to the Console
	 */
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
		transform.Translate(1,1,1);
		print ( DateTime.UtcNow );
		Vector3 pos1 = transform.position;
		Vector3 pos2 = playerTransformCache.position;
		float distance = Vector3.Distance(pos1, pos2);
		float halfDistance = mathObjectCache.Halve(distance);
		Profile.EndProfile("Method-3");
	}

	// ----- method 4 ----------
	private void FindDistanceMethod4(){
		Profile.StartProfile("Method-4");

		print ( DateTime.UtcNow );
		cameraTransformCache.Translate(1,1,1);
		print ( DateTime.UtcNow );
		Vector3 pos1 = cameraTransformCache.position;
		Vector3 pos2 = playerTransformCache.position;
		float distance = Vector3.Distance(pos1, pos2);
		float halfDistance = mathObjectCache.Halve(distance);
		Profile.EndProfile("Method-4");
	}

}