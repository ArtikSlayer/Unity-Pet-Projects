using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public LevelManeger levelManeger;

	void Start () {

		levelManeger = FindObjectOfType<LevelManeger> ();

	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Hero") {

			levelManeger.currentCheckpoint = gameObject;
			Debug.Log("Activated Checkpoint");

		}
	}
}
