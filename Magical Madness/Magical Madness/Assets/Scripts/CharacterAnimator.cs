using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {

	const float locamotionAnimationSmoothTime = .1f;
	Animator animator;

	public Vector3 movement = Vector3.zero;
	//private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("speedPercent", movement.x,.1f,Time.deltaTime);
	}
}
