using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

	public float gravityModifier = 1f;

	protected Rigidbody2D rb2d;
	public Vector2 velocity;


	void OnEnable()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		velocity += gravityModifier * Physics2D.gravity * Time.deltaTime; 

		Vector2 deltaPosition = velocity * Time.deltaTime;

		Vector2 move = Vector2.up * deltaPosition.y;

		Movement (move);
	}

	void Movement(Vector2 move)
	{
		rb2d.position = rb2d.position + move;
	}
}
