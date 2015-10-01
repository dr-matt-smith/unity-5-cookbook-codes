using UnityEngine;
using System.Collections;

/*------------------------------------------------
 * LOTS of calculations, to give us something to measure when calculating FPS (Frames Per Second)
 */
public class SomeCalculations : MonoBehaviour
{
	public int outerLoopIterations = 20;
	public int innerLoopMaxIterations = 100;

	void Update()
	{
		for (int i = 0; i < outerLoopIterations; i++){
			int innerLoopIterations = Random.Range(2,innerLoopMaxIterations);
			for (int j = 0; j < innerLoopIterations; j++){
				float n = Random.Range(-1000f, 1000f);
			}
		}
	}
}