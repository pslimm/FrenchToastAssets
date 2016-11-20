using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	bool facingRight = true;
	public Animator animateEnemy;
	public GameObject target;
	private float targetPosition;

	// Use this for initialization
	void Start () 
	{
		this.targetPosition = target.transform.position.x;
		animateEnemy = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if((targetPosition > this.transform.position.x) && (!facingRight))
		{
			Flip();
		}
		else if((targetPosition < this.transform.position.x) && (facingRight))
		{
			Flip();
		}
	}

	void Flip ()//changes direction enemy faces
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
