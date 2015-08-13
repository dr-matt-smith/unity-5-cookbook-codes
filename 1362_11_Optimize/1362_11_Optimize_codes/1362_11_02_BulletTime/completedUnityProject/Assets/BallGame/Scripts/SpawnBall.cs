// file: SpawnBall.cs
using UnityEngine;
using System.Collections;

/*
 * class for behaviour that creates new taget balls in the game world at regular intervals
 */
public class SpawnBall : MonoBehaviour
{
	// time (seconds) between new balls being created
	private const float RELEASE_DELAY = 3f;

	// reference to ball prefab object to be created
	public Rigidbody ballPrefab;

	// the time at which the next ball should be instantiated
	private float nextRelease = 0.0f;

	// every frame check whether it is time to spawn a new ball
	private void Update() {
		// IF current time is later than next ball creation time
		if (Time.time > nextRelease) {
			// THEN call method to spawn a new ball prefab
			SpawnNextBall();
		}
	}

	// create a new ball prefab at the position and orientation of the gameobject on which this script class instance is a component
	private void SpawnNextBall()
	{
		// calcualte the time for the next ball to be created
		// (current time + time between spanwing)
		nextRelease = Time.time + RELEASE_DELAY;

		// create new prefab instance at the position and orientation of the gameobject on which this script class instance is a component
		Instantiate(ballPrefab, transform.position, transform.rotation);
	}
}