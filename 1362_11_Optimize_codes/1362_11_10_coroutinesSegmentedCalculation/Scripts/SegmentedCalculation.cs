// file: SegmentedCalculation.cs
using UnityEngine;
using System.Collections;

public class SegmentedCalculation : MonoBehaviour {
	private const int ARRAY_SIZE = 50;
	private const int SEGMENT_SIZE = 10;
	private int[] randomNumbers;
	
	private void Awake(){
		randomNumbers = new int[ARRAY_SIZE];
		for(int i=0; i<ARRAY_SIZE; i++){
			randomNumbers[i] = Random.Range(0, 1000);
		}
	
		StartCoroutine( FindMinMax() );
	}
	
	private IEnumerator FindMinMax() {
		int min = 9999;
		int max = -1;
		
		for(int i=0; i<ARRAY_SIZE; i++){
			if( i % SEGMENT_SIZE == 0){
				print("frame: " + Time.frameCount + ", i:" + i + ", min:" + min + ", max:" + max);

				// suspend for 1 frame since we've completed another segment
				yield return null;				
			}
			
			if( randomNumbers[i] > max){
				max = randomNumbers[i];
			} else if( randomNumbers[i] < min){
				min = randomNumbers[i];
			}
		}
	
		// disable this scripted component
		print("** completed - disabling scripted component");
		enabled = false;
		
	}
}
