using UnityEngine;
using System.Collections;

/*
 * class for a WayPoint
 *
 * allows each WayPoint to have an array of possible desinttion WayPoints
 *
 * so we can represent a 'net' of WayPoints, whereby when arring at one we have a choice of next desintation
 */
public class Waypoint: MonoBehaviour {
	public Waypoint[] waypoints;

	/*--------------------------------------------------
	 * return a random member of array 'waypoints'
	 */
	public Waypoint GetNextWaypoint ()
	{
		return waypoints[ Random.Range(0, waypoints.Length) ];
	}
}
