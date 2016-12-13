using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour 
{
	public AudioClip menuSound;
	private	AudioSource audio;
	void Start () 
	{
		AudioListener.pause = false;
		audio = GetComponent<AudioSource>();
		MainMenuPlay();

	}

	public void MainMenuPlay()
	{
		audio.clip = menuSound;
		audio.loop = true;
		audio.Play();
	}

}







