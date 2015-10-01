using UnityEngine;
using System.Collections;

public class DIYProfiling : MonoBehaviour
{
	public int outerLoopIterations = 20;
	public int innerLoopMaxIterations = 100;
	
	/*------------------------------------------------
	 * start profile - with easy to find name
	 *
	 * then loop to do lots of calculations
	 *
	 * then end the profile
	 */
	void Update()
	{
		string profileName = "MATT_calculations1";
		Profile.StartProfile(profileName);

		for (int i = 0; i < outerLoopIterations; i++){
			int innerLoopIterations = Random.Range(2,innerLoopMaxIterations);
			for (int j = 0; j < innerLoopIterations; j++){
				float n = Random.Range(-1000f, 1000f);
			}
		}
		
		Profile.EndProfile(profileName);
	}

	private void OnApplicationQuit()
	{
		Profile.PrintResults();
	}
}
