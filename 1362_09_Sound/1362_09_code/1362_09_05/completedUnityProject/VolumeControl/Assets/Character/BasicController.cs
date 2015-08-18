using UnityEngine;
using System.Collections;

	public class BasicController : MonoBehaviour {
	private Animator animator;
	private CharacterController controller;
	public float DirectionDampTime = .25f;
	private Vector3 deltaPosition;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
	private float jumpPos = 0.0f;
	private float verticalSpeed = 0;
	private float xVelocity = 0.0f;
	private float zVelocity = 0.0f;
 
	void Start () {
	controller = GetComponent<CharacterController>();
	animator = GetComponent<Animator>();
	if(animator.layerCount >= 2)
			animator.SetLayerWeight(1, 1);
	}
	
	void Update () {
	
	float accel = 1.0f;	
	if(controller.isGrounded){	
		
		if (Input.GetKey(KeyCode.Space)) {
			
			animator.SetBool("Jump", true);
			verticalSpeed = jumpSpeed;
          }else{
			animator.SetBool("Jump", false);                
            }
		if (Input.GetKey (KeyCode.RightShift)|| Input.GetKey (KeyCode.LeftShift)){
			accel = 2.0f;	
		} else {
			accel = 1.0f;	
		}
		
		float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
			
		animator.SetFloat("Speed", (h*h+v*v) * accel, DirectionDampTime, Time.deltaTime );
        animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		animator.SetFloat("ZDirection", v, DirectionDampTime, Time.deltaTime);
		//transform.Rotate(Vector3.up * (Time.deltaTime * v * Input.GetAxis("Mouse X") * 90), Space.World);
		
		if(Input.GetKey(KeyCode.Q)){
				animator.SetBool("TurnLeft", true);
				transform.Rotate(Vector3.up * (Time.deltaTime * -45.0f), Space.World);
		}  else {
		animator.SetBool("TurnLeft", false);	
		}
		if(Input.GetKey(KeyCode.E))
		{
			animator.SetBool("TurnRight", true);
			transform.Rotate(Vector3.up * (Time.deltaTime * 45.0f), Space.World);
				
		}  else {
		animator.SetBool("TurnRight", false);	
		}
		if(Input.GetKeyDown(KeyCode.F) && animator.layerCount >= 2){
				animator.SetBool("Grenade", true);
		} else {
			animator.SetBool("Grenade", false);
		}
		if(Input.GetButtonDown("Fire1") && animator.layerCount >= 2){
				animator.SetBool("Fire", true);
		}
		if(Input.GetButtonUp("Fire1") && animator.layerCount >= 2){
			animator.SetBool("Fire", false);
		}
	


			
		}
		

	
	}
	
	
	void OnAnimatorMove(){
		
		

		Vector3 deltaPosition = animator.deltaPosition;
		
			
		
		//float dir = animator.rootRotation.y;
		//dir = 1.0f;
		//print ("dir: " + dir + "rot: " + animator.rootRotation.y);
		
		if(controller.isGrounded){
		xVelocity = animator.GetFloat("Speed")  * controller.velocity.x * 0.25f;
		zVelocity = animator.GetFloat("Speed") * controller.velocity.z * 0.25f;
		//print (controller.velocity);
		}
		
		verticalSpeed += Physics.gravity.y * Time.deltaTime;	
		//print (verticalSpeed);
		
	
		
		if(verticalSpeed <= 0){
			animator.SetBool("Jump", false);  
		}
				
		deltaPosition.y = verticalSpeed * Time.deltaTime;
				
		
		if(!controller.isGrounded){
	    deltaPosition.x = xVelocity * Time.deltaTime;
		deltaPosition.z = zVelocity * Time.deltaTime;
		
			
			
		}


			//if (controller.Move(deltaPosition) == CollisionFlags.Below) verticalSpeed = 0;			
		//if (controller.Move(deltaPosition) == CollisionFlags.Below){
		//verticalSpeed = 0;
		//} else {
			
		//}
		controller.Move(deltaPosition);
		if ((controller.collisionFlags & CollisionFlags.Below) != 0){
		verticalSpeed = 0;	
		
		}
		transform.rotation = animator.rootRotation;
	}
	}
