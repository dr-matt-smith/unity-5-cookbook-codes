using UnityEngine;
using System.Collections;

public class ArrowNPCMovement : MonoBehaviour {
	// object location to head towards
	// public - so set in Inspector via drag-and-drop
	public GameObject targetGO;

	// reference to GameObject NavMeshAgent component
	private NavMeshAgent navMeshAgent;
	
	/*----------------------------------------------------------*/
	// cache reference to navMeshAgent component
	// tell agent to head for destination (targetGO position)
	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		HeadForDestintation();
	}

	/*----------------------------------------------------------*/
	// tell agent to head for position of 'targetGO'
	private void HeadForDestintation ()
	{
		Vector3 destinaton = targetGO.transform.position;
		navMeshAgent.SetDestination (destinaton);
	}
}
