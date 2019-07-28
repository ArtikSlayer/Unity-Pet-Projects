using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public AudioSource jumpSoundEffect;
	
	[Header ("Движение")]
	public float JumpHeight;
	public float moveSpeed;
	private bool doubleJumped;
	private float moveVelocity;
	
	
	[Header ("Земля")]
	[Space(10)]
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	
	[Header ("Отбрасывание")]
	[Space(10)]
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool  knockbackFromRight;
	
	private Animator anim;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		
	}
	
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position,groundCheckRadius,whatIsGround);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 0f)
		{
			return;
		}
		
		if (grounded) 
		{
			doubleJumped=false;
		}
		
		anim.SetBool ("Grounded", grounded);
		
		if (Input.GetKeyDown (KeyCode.Space) && grounded) 
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
			Jump ();
		}
		
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) 
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
			Jump ();
			doubleJumped=true;
		}
		
		moveVelocity = 0f;
		
		if (Input.GetKey (KeyCode.D)) 
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
		}
		
		if (Input.GetKey (KeyCode.A))
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
		}
		
		if (knockbackCount <= 0) {
			
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
			
		} else {
			
			if(knockbackFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback, knockback);
			
			if(!knockbackFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback, knockback);
			
			knockbackCount -= Time.deltaTime;
		}
		
		var speed = Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x);
		anim.SetFloat ("Speed", speed);
		
		if(speed > 0.1f)
		{
			//Баг блоха.
			if(GetComponent<Rigidbody2D>().velocity.x > 0)
				transform.localScale = new Vector3(4f,4f,4f);
			else if(GetComponent<Rigidbody2D>().velocity.x < 0)
				transform.localScale = new Vector3(-4f,4f,4f);
		}
	}
	

	public void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
		jumpSoundEffect.Play ();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}
	}
	
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = null;
		}
	}
}
