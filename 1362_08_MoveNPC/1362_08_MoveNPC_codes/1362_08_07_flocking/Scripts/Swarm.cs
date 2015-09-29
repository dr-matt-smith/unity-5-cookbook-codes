using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Swarm : MonoBehaviour {
	// number of drones to create
	public int droneCount = 20;

	// reference to prefab GameObject to be instantiated 'droneCount' times
	public GameObject dronePrefab;

	// List of references to drone GameObjects that have been created
	private List<Drone> drones = new List<Drone>();


	/*----------------------------------------------------------
	 * add 'droneCount' prefabs to the scene
 	 */
	void Awake()
	{
		for (int i = 0; i < droneCount; i++){
			AddDrone();
		}
	}
	
	/*----------------------------------------------------------
	 * each frame re-calculate and store average position and movement velocity for the swarm
 	 */
	void FixedUpdate()
	{
		Vector3 swarmCenter = SwarmCenterAverage();
		Vector3 swarmMovement = SwarmMovementAverage();

		foreach(Drone drone in drones ) {
			drone.UpdateVelocity(swarmCenter, swarmMovement);
		}
	}


	/*----------------------------------------------------------
	 * create a new drone GameObject, and add a referene to this new object
	 * to List 'drones'
 	 */
	private void AddDrone()
	{
		GameObject newDroneGO = (GameObject)Instantiate(dronePrefab);
		Drone newDrone = newDroneGO.GetComponent<Drone>();
		drones.Add(newDrone);
	}

	/*----------------------------------------------------------
	 * loop through all drones to calculate and return the average position as Vector3 (x,y,z)
 	 */
	private Vector3 SwarmCenterAverage()
	{
		// cohesion (swarm center point)
		Vector3 locationTotal = Vector3.zero;

		foreach(Drone drone in drones ) {
			locationTotal += drone.transform.position;
		}
		
		return (locationTotal / drones.Count);
	}
	
	/*----------------------------------------------------------
	 * loop through all drones to calculate and return the average movement velocity as Vector3 (x,y,z)
 	 */
	private Vector3 SwarmMovementAverage()
	{
		// alignment (swarm direction average)
		Vector3 velocityTotal = Vector3.zero;

		foreach(Drone drone in drones )
		{
			velocityTotal += drone.GetComponent<Rigidbody>().velocity;
		}

		return (velocityTotal / drones.Count);	
	}	
}
