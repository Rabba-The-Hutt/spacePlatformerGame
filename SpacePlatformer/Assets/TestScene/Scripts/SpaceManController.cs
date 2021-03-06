using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Basic character control class
 * current functionality:
 * - Jump
 * - Move forwards/backwards
 */ 



public class SpaceManController : MonoBehaviour {

	public bool jump = false;
	public bool facingRight = true;

	//Basic movement variables - will change depending on planet/level
	public float moveForce = 200.0f;
	public float maxSpeed = 3.0f;
	public float jumpHeight = 7.0f;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {

		//Check to see if spacebar/joypadButton3 has been pressed
		//&& that the player is on the ground y velocity == 0.
		if(Input.GetButtonDown("Jump") && rb2d.velocity.y == 0)
		{
			jump = true;		
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");

		//If character is moving slower then max speed
		//then speed him up.
		if (h * rb2d.velocity.x < maxSpeed) {
			rb2d.AddForce(Vector2.right * h * moveForce);
		}

		//if character is moving slower than max speed then
		//then slow him down
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}

		//if jump is set to true then apply jumpForce on the x axis
		if(jump){
			rb2d.velocity = new Vector2(0, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * jumpHeight));
			jump = false;
		}

		/*
		 * Checks to see which direciton the character
		 * is facing and changes direction accordingly
		 */ 
		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
			Flip ();
		}
	}

	/*
	 * Flips the sprite depending on the direction that
	 * they are facing on the Horizontal axis.
	 */ 
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
