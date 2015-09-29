using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour 
{
	// array of waypoint GameObjects
	public GameObject[] waypoints;

	/*----------------------------------------------------------
	 * return reference to next waypoint in array
	 * if we are at end of array, then return reference to first in the array ...
 	 */
	public GameObject NextWaypoint (GameObject current)
	{
		if( waypoints.Length < 1)
			Debug.LogError ("WaypointManager:: ERROR - no waypoints have been added to array!");
		
		// default is first in the array
		int nextIndex = 0;
		
		// find array index of given waypoint
		int currentIndex = -1;
		for(int i = 0; i < waypoints.Length; i++){
			if( current == waypoints[i] )
				currentIndex = i;
		}
		
		int lastIndex = (waypoints.Length - 1);
		if(currentIndex > -1 && currentIndex < lastIndex)
			nextIndex = currentIndex + 1;
		
		return waypoints[nextIndex];
	}
}