using UnityEngine;
using System.Collections;

public class MegamanController : MonoBehaviour 
{
	public float maxSpeed = 30f;
	bool facingRight = true;
	public Animator animatePlayer;

	bool onGround = false;
	public Transform checkForGround;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround; // tell character what is considered "ground"
	public float jumpForce = 700.0f;

	// Use this for initialization
	void Start() 
	{
		animatePlayer = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{
		// Checking if it hit anywhere or not
		onGround = Physics2D.OverlapCircle(checkForGround.position, groundRadius, whatIsGround); 

		animatePlayer.SetBool("OnGround", onGround);
		animatePlayer.SetFloat("vSpeed",GetComponent<Rigidbody2D>().velocity.y); // vertical speed


		//float move = Input.GetAxis("Horizontal");

		//animatePlayer.SetFloat("Speed", Mathf.Abs(move));
		animatePlayer.SetFloat("Speed", Mathf.Abs(maxSpeed));

		GetComponent<Rigidbody2D>().velocity = new Vector2 (/*move **/ maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        

		/*if (move > 0 && !facingRight) {
			Flip();
		} 
		else if (move < 0 && facingRight) 
		{
			Flip();
		}*/

	}

	void Update()
	{
		if (onGround && Input.GetKeyDown (KeyCode.Space)) 
		{
			// animatePlayer.SetBool ("onGround", false); // no longer on ground
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip() // flips character around. now we don't have to animate in the other direction
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
        

	}
}
