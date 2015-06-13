using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {
	public GameObject prefabBall;
	private SpawnPointManager spawnPointManager;
	private float destroyAfterDelay = 1;

	void Start (){
		spawnPointManager = GetComponent<SpawnPointManager> ();
	}
		
	void Update() {
		if(Input.GetButton("Fire1"))
			CreateSphere();			
	}
	
	private void CreateSphere(){
		GameObject spawnPoint = spawnPointManager.RandomSpawnPoint ();
//		GameObject spawnPoint = spawnPointManager.NearestSpawnpoint(transform.position);

		GameObject newBall = (GameObject)Instantiate (prefabBall, spawnPoint.transform.position, Quaternion.identity);
		Destroy(newBall, destroyAfterDelay);
	}
}
