using UnityEngine;
using System.Collections;

public class TimedMethod : MonoBehaviour
{
	/*----------------------------------------------
	 * when GameObject created, start our co-routine
	 */
	private void Start()
	{
		StartCoroutine(Tick());
	}
	
	/*----------------------------------------------
	 * a forever loop
	 * print out a tick, then wait for 'delaySeconds' before re-entering the loop
	 */
	private IEnumerator Tick()
	{
		float delaySeconds = 5.0F;
		while (true) {
			print("tick " + Time.time);
			yield return new WaitForSeconds(delaySeconds);
		}
	}
}
