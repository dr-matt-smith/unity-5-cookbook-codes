using UnityEngine;
using System.Collections;

public class ArrowNPCMovement : MonoBehaviour {
	public GameObject targetGO;
	private NavMeshAgent navMeshAgent;
	private float runAwayMultiplier = 2;
	private float runAwayDistance;
	
	void Start(){
		navMeshAgent = GetComponent<NavMeshAgent>();
		runAwayDistance = navMeshAgent.stoppingDistance * runAwayMultiplier;
	}
	
	void Update () {
		Vector3 enemyPosition = targetGO.transform.position;
		float distanceFromEnemy = Vector3.Distance(transform.position, enemyPosition);
		if (distanceFromEnemy < runAwayDistance)
			FleeFromTarget (enemyPosition);
	}

	private void FleeFromTarget(Vector3 enemyPosition){
		Vector3 fleeToPosition = Vector3.Normalize(transform.position - enemyPosition) * runAwayDistance;
		HeadForDestintation(fleeToPosition);
	}
	
	private void HeadForDestintation (Vector3 destinationPosition){
		navMeshAgent.SetDestination (destinationPosition);
	}
}
