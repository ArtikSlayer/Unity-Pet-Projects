using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;

	public string mainMenu;

	public bool isPaused;

	public GameObject pauseMenuCanvas;


	// Update is called once per frame
	private LifeManager fromLM;

	void Start()
	{
		fromLM = FindObjectOfType<LifeManager>();
	}

	void Update () {
	
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

			if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (fromLM.gameOverScreen.activeSelf)
			{
				return;
			}
				isPaused = !isPaused;
		}

	}
	public void Resume()
	{
		isPaused = false;
	}

	public void  LevelSelect()
	{	
		Application.LoadLevel (levelSelect);
	}

	public void Quit()
	{
		Application.LoadLevel (mainMenu);
	}
}
