using UnityEngine;
using System.Collections;

public class PauseMenuButtons : MonoBehaviour 
{
	public GameObject pauseMenuButtons;
	public GameObject pauseButton;

	void Start () 
	{
		pauseMenuButtons.SetActive(false);
	}

}
