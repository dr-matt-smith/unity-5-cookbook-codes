using UnityEngine;
using System.Collections;

public class ObjectBuilderScript : MonoBehaviour {
	void Awake(){
		gameObject.SetActive(false);
	}
	
	public void AddObjectToScene(GameObject prefabToCreateInScene){
		GameObject newGO = (GameObject)Instantiate(prefabToCreateInScene, transform.position, Quaternion.identity);
		newGO.name = prefabToCreateInScene.name;
	}
}
