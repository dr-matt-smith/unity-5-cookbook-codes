// file: RandomPositionManager.cs
using UnityEngine;
using System.Collections;
 
public class RandomPositionManager : MonoBehaviour
{
	public static ArrayList BuildVector3ArrayList(int numPositions){
		ArrayList positionArrayList = new ArrayList();
		for(int i=0; i < numPositions; i++) {
			float x = Random.Range(0, 100);
			float y = Random.Range(0, 100);
			float z = Random.Range(0, 100);
			Vector3 pos = new Vector3(x,y,z);
			positionArrayList.Add (pos);
		}
		
		return positionArrayList;
	}
	
	public static float[] BuildFloatArray(int numPositions){
		float[] floatArray = new float[numPositions];
		for(int i=0; i < numPositions; i++) {
			floatArray[i] = Random.Range(0, 100);
		}
		
		return floatArray;
	}
}