using UnityEngine;
using System.Collections;

public class ArrowNPCMovement : MonoBehaviour {
	private GameObject targetGO = null;
	private WaypointManager waypointManager;
	private NavMeshAgent navMeshAgent;
	
	void Start ()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		waypointManager = GetComponent<WaypointManager>();
		HeadForNextWayPoint();
	}

	void Update () 
	{
		float closeToDestinaton = navMeshAgent.stoppingDistance * 2;
		if (navMeshAgent.remainingDistance < closeToDestinaton){
			HeadForNextWayPoint ();
		}
	}

	private void HeadForNextWayPoint ()
	{
		targetGO = waypointManager.NextWaypoint (targetGO);
		navMeshAgent.SetDestination (targetGO.transform.position);
	}
}
