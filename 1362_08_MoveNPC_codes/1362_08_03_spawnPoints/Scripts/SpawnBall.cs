using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {
	public GameObject prefabBall;
	private SpawnPointManager spawnPointManager;
	private float destroyAfterDelay = 1;
	private float testFireKeyDelay = 0;

	void Start (){
		spawnPointManager = GetComponent<SpawnPointManager> ();
		StartCoroutine("CheckFireKeyAfterShortDelay");
	}
		
	IEnumerator CheckFireKeyAfterShortDelay () {
		while(true){
			yield return new WaitForSeconds(testFireKeyDelay);
			testFireKeyDelay = 0; // now check every frame
			CheckFireKey();
		}
	}
	
	private void CheckFireKey() {
		if(Input.GetButton("Fire1")){
			CreateSphere();	
			testFireKeyDelay = 0.5f;
		}
	}
	
	private void CreateSphere(){
		GameObject spawnPoint = spawnPointManager.RandomSpawnPoint ();
//		GameObject spawnPoint = spawnPointManager.NearestSpawnpoint(transform.position);

		// only try to instantiate prefab if spawnpoint is NOT null
		if(spawnPoint){
			GameObject newBall = (GameObject)Instantiate (prefabBall, spawnPoint.transform.position, Quaternion.identity);
			Destroy(newBall, destroyAfterDelay);
		}
	}
}
