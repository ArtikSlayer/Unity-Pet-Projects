using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvercookedLikeMovement : MonoBehaviour {

	public float speed = 2f;
	
	private Vector3 moveVector;
	
	void FixedUpdate () {

		HandleInput();
		
		transform.Rotate(Vector3.up, Angle360(transform.forward, moveVector, transform.right));
		
		transform.Translate(
			Moves() * transform.forward * speed * Time.deltaTime,
			Space.World
			);
	}
	
	void HandleInput() {
		moveVector.x = Input.GetAxis("Horizontal");
		moveVector.z = Input.GetAxis("Vertical");
	}
	
	float Moves() {
		if(moveVector.x != 0 || moveVector.z != 0)
			return 1f;
		else
			return 0f;
	}
	
	float Angle360(Vector3 from, Vector3 to, Vector3 right) {
		float angle = Vector3.Angle(from, to);
		return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
	}
}
