 using UnityEngine;
using System.Collections;

public class DestroyOnCon : MonoBehaviour 
{
	UIHandler UIHCSs;
	public GameObject deathPartical;
	public GameObject blast;
	Music music;
	void Start()
	{
		UIHCSs = GameObject.FindObjectOfType(typeof(UIHandler)) as UIHandler;
		music = GameObject.FindObjectOfType(typeof(Music)) as Music;

	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Handheld.Vibrate();
			UIHCSs.SubLife();
			music.DamagePlay();
			Destroy(other.gameObject);
	
		}
		if(other.gameObject.tag == "Base")
		{
			Handheld.Vibrate();
			UIHCSs.SubLife();
			music.DamagePlay();

	
		}
		if(other.gameObject.tag == "EnemyBullet" )
		{
			Handheld.Vibrate();
			UIHCSs.SubLife();
			music.DamagePlay();
			Destroy(other.gameObject);


		}
		if(other.gameObject.tag == "Coin1" )
		{
		
			Destroy(other.gameObject);
			music.CoinPlay();
			UIHCSs.AddCoin();
		}

		if(other.gameObject.tag == "Life" )
		{
			
			Destroy(other.gameObject);
			music.LifePlay();
			UIHCSs.AddLife();
		}



	}
	public	void DestroyPlayer()
	{
		Destroy(gameObject);
	}
}
