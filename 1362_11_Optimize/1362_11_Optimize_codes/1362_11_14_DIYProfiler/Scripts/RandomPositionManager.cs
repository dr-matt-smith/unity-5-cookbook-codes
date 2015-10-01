// file: RandomPositionManager.cs
using UnityEngine;
using System.Collections;
 
public class RandomPositionManager : MonoBehaviour
{
	/*----------------------------------------------------
	 * build and return an array of Vector3 objects
	 * the size of the array should be the provided 'numPositions'
	 */
	public static ArrayList BuildVector3ArrayList(int numPositions)
	{
		ArrayList positionArrayList = new ArrayList();
		for(int i=0; i < numPositions; i++) {
			//
			// each x/y/z value is a random floats in the range 0..100
			float x = Random.Range(0, 100);
			float y = Random.Range(0, 100);
			float z = Random.Range(0, 100);
			Vector3 pos = new Vector3(x,y,z);
			positionArrayList.Add (pos);
		}
		
		return positionArrayList;
	}
	
	/*----------------------------------------------------
	 * build and return an array of floats
	 * the size of the array should be the provided 'numPositions'
	 */
	public static float[] BuildFloatArray(int numPositions)
	{
			//
			// each value is a float somewhere in the range 0..100
		float[] floatArray = new float[numPositions];
		for(int i=0; i < numPositions; i++) {
			floatArray[i] = Random.Range(0, 100);
		}
		
		return floatArray;
	}
}