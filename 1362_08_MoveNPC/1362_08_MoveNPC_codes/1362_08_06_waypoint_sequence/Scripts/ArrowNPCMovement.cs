using UnityEngine;
using System.Collections;

public class ArrowNPCMovement : MonoBehaviour {
	// the GameObject towards which we are curently heading towards
	private GameObject targetGO = null;

	// referencd to out way point manager object
	private WaypointManager waypointManager;

	// reference to a NavMeshAgent
	private NavMeshAgent navMeshAgent;
	
	/*----------------------------------------------------------
	 * cache references to navmeshagent and waypointmanager sibling components
	 * in parent GameObject
 	 */
	void Start ()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		waypointManager = GetComponent<WaypointManager>();
		HeadForNextWayPoint();
	}

	/*----------------------------------------------------------
	 * if we are close to 'targetGO' then call 'HeadForNextWayPoint()'
 	 */
	void Update ()
	{
		float closeToDestinaton = navMeshAgent.stoppingDistance * 2;
		if (navMeshAgent.remainingDistance < closeToDestinaton){
			HeadForNextWayPoint ();
		}
	}

	/*----------------------------------------------------------
	 * get next destinaton from waypointmanager, providing it with our current (nearby) destination
 	 */
	private void HeadForNextWayPoint ()
	{
		targetGO = waypointManager.NextWaypoint (targetGO);
		navMeshAgent.SetDestination (targetGO.transform.position);
	}
}
