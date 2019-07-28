using UnityEngine;
using System.Collections;

public class LevelManeger : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public HealthManager healthManager;

	[Space(10)]
	[Header ("Штраф")]
	public int pointPenaltyOnDeath;
	

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();

		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		player.enabled = false;//почитать про enabled;
		//player.GetComponent<Renderer> ().enabled = false;
		Debug.Log ("Player Respawn");
		player.knockbackCount = 0f;
		player.transform.position = currentCheckpoint.transform.position;

		player.enabled = true;//почитать про enabled;
		//player.GetComponent<Renderer> ().enabled = true;
		//player.knockbackCount = 0;

		healthManager.FullHealth ();
	}

	//Из урока про монетки для двигающейся камеры после смерти https://www.youtube.com/watch?v=J4dkxdbe8FI
}
