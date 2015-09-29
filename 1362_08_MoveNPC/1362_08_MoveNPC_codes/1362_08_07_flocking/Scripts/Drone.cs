using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {
	// reference to NavMeshAgent component
	private NavMeshAgent navMeshAgent;

	/*----------------------------------------------------------*/
	// cache reference to NavMeshAgent component of parent GameObject
	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	/*----------------------------------------------------------*/
	// combine swawn center and movement average
	// into vector parent GammeObject should move towards
	public void UpdateVelocity(Vector3 swarmCenterAverage, Vector3 swarmMovementAverage)
	{
		Vector3 destination = swarmCenterAverage + swarmMovementAverage;
		navMeshAgent.SetDestination(destination);
	}
}