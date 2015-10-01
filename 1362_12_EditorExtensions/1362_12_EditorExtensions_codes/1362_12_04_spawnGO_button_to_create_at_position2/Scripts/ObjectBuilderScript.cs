using UnityEngine;
using System.Collections;

public class ObjectBuilderScript : MonoBehaviour
{
	/*-------------------------------------------------
	 * when scene runs, de-activate the parent GameObject
	 */
	void Awake()
	{
		gameObject.SetActive(false);
	}
	
	/*-------------------------------------------------
	 * when called, with provided prefab
	 * create an instance at location of parent GameObject
	 *
	 * name the new GameObject to be the same as the name of the prefab
	 */
	public void AddObjectToScene(GameObject prefabToCreateInScene)
	{
		GameObject newGO = (GameObject)Instantiate(prefabToCreateInScene, transform.position, Quaternion.identity);
		newGO.name = prefabToCreateInScene.name;
	}
}
