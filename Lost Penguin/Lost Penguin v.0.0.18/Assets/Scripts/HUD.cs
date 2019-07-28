using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HertSprites;

	public Image HeartUI;

	//private HealthManager helthManager;
	public PlayerController player;//был private

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		//helthManager = FindObjectOfType<HealthManager>();
    }
	void Update()
	{

		HeartUI.sprite = HertSprites[HealthManager.playerCurHealth];

	}
}