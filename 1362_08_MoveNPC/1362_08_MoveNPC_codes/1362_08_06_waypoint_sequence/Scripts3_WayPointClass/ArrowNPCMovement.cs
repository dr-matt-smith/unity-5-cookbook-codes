using UnityEngine;
using System.Collections;

public class ArrowNPCMovement : MonoBehaviour {
	public Waypoint waypoint;
	private bool firstWayPoint = true;
	private NavMeshAgent navMeshAgent;
	
	void Start (){
		navMeshAgent = GetComponent<NavMeshAgent>();
		HeadForNextWayPoint();
	}

	void Update () {
		float closeToDestinaton = navMeshAgent.stoppingDistance * 2;
		if (navMeshAgent.remainingDistance < closeToDestinaton){
			HeadForNextWayPoint ();
		}
	}

	private void HeadForNextWayPoint (){
		if(firstWayPoint)
			firstWayPoint = false;
		else
			waypoint = waypoint.GetNextWaypoint();

		Vector3 target = waypoint.transform.position;
		navMeshAgent.SetDestination (target);
	}
}
