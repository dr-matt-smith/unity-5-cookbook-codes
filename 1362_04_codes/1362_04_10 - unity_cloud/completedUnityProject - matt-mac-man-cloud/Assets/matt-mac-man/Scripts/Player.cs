using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public const int SCORE_PILL = 20;
	public AudioSource cherryAudioSource;
	private AudioSource audioSource;
	private float maxSpeed = 10;
	private int score = 0;

	public int GetScore(){	return score;	}

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	void FixedUpdate(){
		// round position - to nearest 0.1 units
		Vector3 position = transform.position;
		transform.position = position;

		// get user input and move as appropriate
		float xMove = Input.GetAxis("Horizontal");
		float yMove = Input.GetAxis("Vertical");

		/*
		if(Mathf.Abs(xMove) > Mathf.Abs(yMove)){
			yMove = 0;
			if(xMove > 0)
				xMove = 1;
			else
				xMove = -1;
		} else {
			xMove = 0;
			if(yMove > 0)
				yMove = 1;
			else 
				yMove = -1;
		}
		*/

		float xSpeed = xMove * maxSpeed;
		float ySpeed = yMove * maxSpeed;
		
		Vector2 newVelocy = new Vector2(xSpeed, ySpeed);
		
		GetComponent<Rigidbody2D>().velocity = newVelocy;	

		// if not moving, center in a square
		/*
		if(newVelocy.magnitude < 0.01){
			float newX = Mathf.Round(position.x * 10)/10;
			float newY = Mathf.Round(position.y * 10)/10;
			transform.position = new Vector3(newX, newY, position.z);
		}
		*/
	}
	
	private void OnTriggerEnter2D(Collider2D hit){
		print ("hit something - tag = " + hit.tag);

		if(hit.CompareTag("Pellet")){
			Destroy(hit.gameObject);
			score += SCORE_PILL;
			PlayerWakaWakaIfQuiet();
		}
		
		if(hit.CompareTag("Cherry")){
			Destroy(hit.gameObject);
			score += SCORE_PILL;
			PlayerWakaWakaIfQuiet();
		}
		
		print ("score = " + score);
	}

	private void PlayerWakaWakaIfQuiet(){
		bool cherrySoundPlaying = cherryAudioSource.isPlaying;
		if(!cherrySoundPlaying && !audioSource.isPlaying)
			audioSource.Play();
	}
}


/*
 * Turn pacman into Sprite
 * add RigidBody 2D
 * set gravity to zero
 * - add this script
 * - check Fixed Angle
 * add Collider
 * 
 * 
 * ==
 * drag in blue wall
 * - add collider
 * 
 * ===
 * - add tag PowerPill to pill prefab
 * - add Collider2D
 * - add script 'DestroyWhenHit'
 * 
 */