using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;

	public static int playerCurHealth;

	private LevelManeger levelManager;

	private LifeManager lifeSystem;

	private TimeManager theTime;

	// Use this for initialization
	void Start () {

		playerCurHealth = maxPlayerHealth;

		levelManager = FindObjectOfType<LevelManeger>();

		lifeSystem = FindObjectOfType<LifeManager>();

		theTime = FindObjectOfType<TimeManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (playerCurHealth <= 0)
		{  
			playerCurHealth = 0;
			levelManager.RespawnPlayer();
			lifeSystem.TakeLife();
			theTime.ResetTime();
		}

		if (playerCurHealth > maxPlayerHealth)
		{
			playerCurHealth = maxPlayerHealth;
		}

	}

	public static void HurtPlayer(int damageToGive)
	{
		playerCurHealth -= damageToGive;
	}

	public void FullHealth()
	{
		playerCurHealth = maxPlayerHealth;
	}

	public void KillPlayer()
	{
		playerCurHealth = 0;
	}
}
