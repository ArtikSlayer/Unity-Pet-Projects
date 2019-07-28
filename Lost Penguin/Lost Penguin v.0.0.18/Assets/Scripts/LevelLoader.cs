using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;

	public string levelToLoad;

	public string levelTag;

	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown (KeyCode.W) && playerInZone) 
		{

			LoadLevel();
		}
	}

	public void LoadLevel()
	{
		PlayerPrefs.SetInt (levelTag,1);
		Application.LoadLevel(levelToLoad);//LoadLevelAsync что-то для обложки и музыки для загрузки:погугли;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Hero") 
		{
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Hero") 
		{
			playerInZone = false;
		}
	}
}
