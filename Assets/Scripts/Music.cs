using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioClip plrPwrUpSound;
	public AudioClip afterGameOverSound;
	public AudioClip coinSound;
	public AudioClip gameOverSound;
	public AudioClip backGroundSound;
	public AudioClip damageSound;
	public AudioClip lifeSound;
	private	AudioSource audio;
	
	void Start() 
	{
		AudioListener.pause = false;
		audio = GetComponent<AudioSource>();
		BackGroundPlay();
	}

	
	
	public void GameOverPlay()
	{

		audio.PlayOneShot(gameOverSound);
	}
	
	public void CoinPlay()
	{
		audio.PlayOneShot(coinSound);
	}
	
	public void BackGroundPause()
	{
		audio.Stop();
	}
	public void BackGroundPlay()
	{
	
		audio.clip = backGroundSound;
		audio.loop = true;
		audio.Play();

	}
	public void AfterGameOverPlay()
	{
		audio.clip = afterGameOverSound;
		audio.loop = true;
		audio.Play();
	}
	public void DamagePlay()
	{
		audio.PlayOneShot(damageSound);
	}
	
	public void LifePlay()
	{
		audio.PlayOneShot(lifeSound);
	}

	public void PlrPwrUpPlay()
	{
		audio.PlayOneShot(plrPwrUpSound);
	}




	
	
}