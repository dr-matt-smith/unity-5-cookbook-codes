using UnityEngine;

public class WaypointManager : MonoBehaviour {
	// 2 waypoints GameObjects
	// public - so set by drag-and-drop in Inspector
	public GameObject wayPoint0;
	public GameObject wayPoint3;


	/*----------------------------------------------------------
	 * given 'current' return the other one
	 * i.e. if current is a reference to 'wayPoint3' then return 'wayPoint0'
	 * else return 'wayPoint3'
	 * so we can all this method to keep swapping which of the 2 waypoints we are heading towards
 	 */
	public GameObject NextWaypoint(GameObject current)
	{
		if(current == wayPoint0)
			return wayPoint3;
		else
			return wayPoint0;
	}
}
