using UnityEngine;
using System.Collections;

public class ScrollZ : MonoBehaviour {
	public float scrollSpeed = 20;

	void Update () {
		Vector3 pos = transform.position;
		Vector3 localVectorUp = transform.TransformDirection(0,1,0);
		pos += localVectorUp * scrollSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
