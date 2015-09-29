using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour
{
	// reference to GameObject prefab to be crated when player hits fire key
	public GameObject prefabBall;

	// reference to our spawn point manager object
	private SpawnPointManager spawnPointManager;

	// lifespan of created objects
	private float destroyAfterDelay = 1;

	// minimum pause between each new object can be created
	private float testFireKeyDelay = 0;


	/*----------------------------------------------------------
	 * cache reference to spawn point manager object
	 * and start 'listener' of fire key presses
	 */
	void Start ()
	{
		spawnPointManager = GetComponent<SpawnPointManager> ();
		StartCoroutine("CheckFireKeyAfterShortDelay");
	}
		
	/*----------------------------------------------------------
	 * after a delay check if fire key has been pressed
	 * repeat forever
	 *
	 * delay is set to zero before calling CheckFireKey()
	 * so if fire key not pressed, we don't wait before checking it next frame
	 */
	IEnumerator CheckFireKeyAfterShortDelay ()
	{
		while(true){
			yield return new WaitForSeconds(testFireKeyDelay);
			testFireKeyDelay = 0; // now check every frame
			CheckFireKey();
		}
	}
	
	/*----------------------------------------------------------
	 * if fire key pressed then create a sphere, and ensure user cannot fire again for a short time
	 */
	private void CheckFireKey()
	{
		if(Input.GetButton("Fire1")){
			CreateSphere();	
			testFireKeyDelay = 0.5f;
		}
	}
	
	/*----------------------------------------------------------
	 * retrieve a randome / nearby spawnpoint from the spawn point manager
	 * can create clone of prefab object (and store reference to new object in 'newBall')
	 * set it to be Destroyed after 'destroyAfterDelay' seconds
	 */
	private void CreateSphere()
	{
		GameObject spawnPoint = spawnPointManager.RandomSpawnPoint ();
//		GameObject spawnPoint = spawnPointManager.NearestSpawnpoint(transform.position);

		// only try to instantiate prefab if spawnpoint is NOT null
		if(spawnPoint){
			GameObject newBall = (GameObject)Instantiate (prefabBall, spawnPoint.transform.position, Quaternion.identity);
			Destroy(newBall, destroyAfterDelay);
		}
	}
}
