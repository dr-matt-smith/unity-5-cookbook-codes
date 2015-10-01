// file: SegmentedCalculation.cs
using UnityEngine;
using System.Collections;

public class SegmentedCalculation : MonoBehaviour
{
	// size of our array
	private const int ARRAY_SIZE = 50;

	// number of array elements to 'process' each frame
	private const int SEGMENT_SIZE = 10;

	// an array to hold lots of random integers
	private int[] randomNumbers;

	/*-----------------------------------------------------------------
	 * build array of random numbers
	 *
	 * then start co-routine to progressively process the array
	 * calculating max and min values
	 */
	private void Awake()
	{
		randomNumbers = new int[ARRAY_SIZE];

		for (int i=0; i<ARRAY_SIZE; i++){
			randomNumbers[i] = Random.Range(0, 1000);
		}
	
		StartCoroutine( FindMinMax() );
	}
	
	/*-----------------------------------------------------------------
	 * loop through all of array 'randomNumbers[]'
	 *
	 * but after SEGMENT_SIZE elements, 'yield'
	 * i.e. pause processing, to allow other actions in the scene for the current frame
	 *
	 * (i % SEGMENT_SIZE == 0) - each time we get to a vaue of 'i' that is an integer multiple of SEGMENT_SIZE
	 * pause until next frame
	 */
	private IEnumerator FindMinMax()
	{
		int min = int.MaxValue;
		int max = int.MinValue;
		
		for(int i=0; i<ARRAY_SIZE; i++){
			if(i % SEGMENT_SIZE == 0){
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
	
		// disable this scripted component - since we've finished processing
		print("** completed - disabling scripted component");
		enabled = false;
		
	}
}
