using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float speed = 10;
	private Rigidbody2D rigidBody2D;
	
	void Awake(){
		rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate(){
		float xMove = Input.GetAxis("Horizontal");
		float yMove = Input.GetAxis("Vertical");
		
		float xSpeed = xMove * speed;
		float ySpeed = yMove * speed;
		
		Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
		
		rigidBody2D.velocity = newVelocity;
	}
}
