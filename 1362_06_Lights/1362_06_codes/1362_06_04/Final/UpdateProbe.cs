using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to update Reflection Probes 
 * via scripting
 */ 
public class UpdateProbe : MonoBehaviour {
	// Provate variable for the ReflectionProbe component of the object this script is attached to
	private ReflectionProbe probe;
	/* ----------------------------------------
	 * At Awake, assign ReflectionProbe component to 
	 * probe' variable and update cubemap
	 */
	void Awake () {
		// Assign assign ReflectionProbe component to 'probe' variable
		probe = GetComponent<ReflectionProbe> ();
		// Use RenderProbe function to update reflection cubemap
		probe.RenderProbe();
	}

	/* ----------------------------------------
	 * A RefreshProbe function to update the cubemap
	 * whenever this function is called
	 */
	public void RefreshProbe(){
		// Use RenderProbe function to update reflection cubemap
		probe.RenderProbe();
	}
}
