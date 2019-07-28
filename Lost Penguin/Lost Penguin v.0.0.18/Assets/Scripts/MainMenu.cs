using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public string levelSelect;

	public string level1Tag;
	public string level2Tag;
	public string level3Tag;
	public string level4Tag;
	public string level5Tag;
	public string level6Tag;


	public void NewGame()
	{
		PlayerPrefs.SetInt (level1Tag,1);
		PlayerPrefs.SetInt (level2Tag,0);
		PlayerPrefs.SetInt (level3Tag,0);
		PlayerPrefs.SetInt (level4Tag,0);
		PlayerPrefs.SetInt (level5Tag,0);
		PlayerPrefs.SetInt (level6Tag,0);
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect()
	{
		//PlayerPrefs.SetInt (level1Tag,1);
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame()
	{
		Debug.Log ("Game Exited");
		Application.Quit ();
	}
}
