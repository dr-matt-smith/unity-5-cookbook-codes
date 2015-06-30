using UnityEngine;
using System.Collections;

public class Waypoint: MonoBehaviour {
	public Waypoint[] waypoints;
	
	public Waypoint GetNextWaypoint () {
		return waypoints[ Random.Range(0, waypoints.Length) ];
	}
}
