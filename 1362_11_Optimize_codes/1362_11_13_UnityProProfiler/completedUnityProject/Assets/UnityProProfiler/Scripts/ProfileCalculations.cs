using UnityEngine;
using System.Collections;
 
public class ProfileCalculations : MonoBehaviour {
	public int outerLoopIterations = 20;
	public int innerLoopMaxIterations = 100;

	void Update(){
		Profiler.BeginSample("MATT_calculations");

		for(int i = 0; i < outerLoopIterations; i++){
			int innerLoopIterations = Random.Range(2,innerLoopMaxIterations);
			for(int j = 0; j < innerLoopIterations; j++){
				float n = Random.Range(-1000f, 1000f);
			}
		}

		Profiler.EndSample();
	}
}