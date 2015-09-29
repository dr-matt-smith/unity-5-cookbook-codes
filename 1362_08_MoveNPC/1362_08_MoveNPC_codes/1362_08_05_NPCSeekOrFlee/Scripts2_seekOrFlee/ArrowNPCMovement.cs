using UnityEngine;
using System.Collections;

public class ArrowNPCMovement : MonoBehaviour {
	public GameObject targetGO;
	public bool fleeFromTarget = true;
	private NavMeshAgent navMeshAgent;
	private float runAwayDistance = 10;
	
	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	/*----------------------------------------------------------*/
	// if fleeing, then call 'PositionToFleeTowards()' to calculted locaiton to flee towards
	// away from 'targetGO'
	void Update () 
	{
		Vector3 desination = targetGO.transform.position;
		if (fleeFromTarget){
			desination = PositionToFleeTowards(targetGO.transform.position);
		}

		HeadForDestintation(desination);
	}

	/*----------------------------------------------------------*/
	private void HeadForDestintation (Vector3 destinationPosition)
	{
		navMeshAgent.SetDestination (destinationPosition);
	}
	
	/*----------------------------------------------------------
	 * rotate in opposite direciton to where targetGO is
	 * set return position of point that is 'runAwayDistance' further away from 'targetGO'
	 * than current position
	 */
	private Vector3 PositionToFleeTowards(Vector3 targetPosition)
	{
		transform.rotation = Quaternion.LookRotation(transform.position - targetPosition);
		Vector3 runToPosition = targetPosition + (transform.forward * runAwayDistance);
		return runToPosition;
		/*
		 * code to ensure our run to position is a valid part of the NavMesh
		NavMeshHit hit;
		NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetAreaFromName("Default"));
		return hit.position;
		*/
	}

}
