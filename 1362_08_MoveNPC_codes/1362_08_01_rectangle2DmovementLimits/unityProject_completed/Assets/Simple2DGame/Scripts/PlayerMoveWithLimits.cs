using UnityEngine;
using System.Collections;

public class PlayerMoveWithLimits : MonoBehaviour {
	public SpriteRenderer movementBoundingSprite;
	private float x_min;
	private float y_min;
	private float x_max;
	private float y_max;

	public float speed = 10;
	private Rigidbody2D rigidBody2D;
	private Rect minMaxRect;

	void Awake(){
		rigidBody2D = GetComponent<Rigidbody2D>();
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		x_min = movementBoundingSprite.bounds.min.x + spriteRenderer.bounds.extents.x;
		y_min = movementBoundingSprite.bounds.min.y + spriteRenderer.bounds.extents.y;
		x_max = movementBoundingSprite.bounds.max.x - spriteRenderer.bounds.extents.x;
		y_max = movementBoundingSprite.bounds.max.y - spriteRenderer.bounds.extents.y;
	}

	void FixedUpdate(){
		float xMove = Input.GetAxis("Horizontal");
		float yMove = Input.GetAxis("Vertical");

		float xSpeed = xMove * speed;
		float ySpeed = yMove * speed;
		
		Vector2 newVelocy = new Vector2(xSpeed, ySpeed);
		
		rigidBody2D.velocity = newVelocy;	

		// restrict player movement
		KeepWithinMinMaxRectangle();
	}

	private void KeepWithinMinMaxRectangle(){
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		float clampedX = Mathf.Clamp(x, x_min, x_max);
		float clampedY = Mathf.Clamp(y, y_min, y_max);
		transform.position = new Vector3(clampedX, clampedY, z);
	}

}

