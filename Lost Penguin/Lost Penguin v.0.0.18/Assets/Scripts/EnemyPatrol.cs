using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	[Header ("Движение")]
	public float moveSpeed;
	public bool moveRight;

	[Space(10)]

	[Header ("Стена")]
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingInWall;

	private bool NotAtEdge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		hittingInWall = Physics2D.OverlapCircle (wallCheck.position,wallCheckRadius,whatIsWall);

		NotAtEdge = Physics2D.OverlapCircle (edgeCheck.position,wallCheckRadius,whatIsWall);

		if (hittingInWall || !NotAtEdge)
			moveRight = !moveRight;

		if (moveRight) 
		{
			transform.localScale = new Vector3(-4f,4f,4f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			transform.localScale = new Vector3(4f,4f,4f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
