using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;

	public AudioSource coinSoundEffect;

	public float angle;

	//public float degree;

	public bool check;

	void Start(){

		angle = transform.rotation.eulerAngles.z;
		check = true;
	}

	void Update(){

		Napr ();

		 if (angle>10) {

			check=!check;

		}else if(angle<350 && angle>340 ){

			check=!check;

		}

	}

	void Napr(){

		if (check) {

			transform.Rotate (Vector3.back * -0.25F);
			angle = transform.rotation.eulerAngles.z;

		} else if(!check){

			transform.Rotate (Vector3.back * 0.25F);
			angle = transform.rotation.eulerAngles.z;

		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;

		ScoreManager.AddPoints(pointsToAdd);

		coinSoundEffect.Play ();

		Destroy (gameObject);
	}
}
