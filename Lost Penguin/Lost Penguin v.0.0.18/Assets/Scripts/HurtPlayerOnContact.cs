using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;

	public AudioSource HurtPlayerSoundEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Hero") {
			HealthManager.HurtPlayer(damageToGive);
			HurtPlayerSoundEffect.Play ();

			var player = other.GetComponent<PlayerController>();
			player.knockbackCount = player.knockbackLength;

			if(other.transform.position.x < transform.position.x)
				player.knockbackFromRight = true;
			else
				player.knockbackFromRight = false;

		}
	}
}
