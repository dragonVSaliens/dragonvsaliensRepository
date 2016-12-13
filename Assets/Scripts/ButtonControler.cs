using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonControler : MonoBehaviour 
{

	public Text muteAndUnMuteText;
	public bool isMute = false;
	public bool IsPuse = false;
	MuteUnMute muteunmutecs;
	PauseMenuButtons pausemenubuttonscs;
	void Start()
	{

		pausemenubuttonscs = GameObject.FindObjectOfType(typeof(PauseMenuButtons)) as PauseMenuButtons;
		muteunmutecs = GameObject.FindObjectOfType(typeof(MuteUnMute)) as MuteUnMute;
	}
	public void onGameStart()
	{		//Application.LoadLevel ("Level1");
		LoadingScreen.LoadScene ("Level1");
	}
	public void onGameQuit()
	{
		Application.Quit();
	}
	public void onMainMenu()
	{
		Time.timeScale = 1;
		LoadingScreen.LoadScene("MainMenu");
	}
	public void OnPause()
	{
		pausemenubuttonscs.pauseMenuButtons.SetActive(true);
		Time.timeScale = 0;
		pausemenubuttonscs.pauseButton.SetActive(false);
	}

	public void OnMuteAndUnMute()
	{
		isMute = !isMute;
		if (isMute) 
		{
			muteAndUnMuteText.text = "sound on";
			AudioListener.pause = true;
		} 
		else if (!isMute)
		{
			muteAndUnMuteText.text = "sound off";
			AudioListener.pause = false;
		}
		
	}

	public void OnResume()
	{
		pausemenubuttonscs.pauseButton.SetActive(true);
		Time.timeScale = 1;
		pausemenubuttonscs.pauseMenuButtons.SetActive(false);
	}

	public void Mute()
	{
		AudioListener.pause = true;
		muteunmutecs.Mute.SetActive(false);
		muteunmutecs.UnMute.SetActive(true);
	}


	public void UnMute()
	{
		AudioListener.pause = false;
		muteunmutecs.UnMute.SetActive(false);
		muteunmutecs.Mute.SetActive(true);
	}


}
