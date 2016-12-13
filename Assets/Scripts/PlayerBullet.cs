using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour 
{
	UIHandler handdler;
	PlayerController playerCS;
	public GameObject blast;
	public GameObject deathPartical;

	void Start()
	{

		handdler = GameObject.FindObjectOfType(typeof(UIHandler)) as UIHandler;

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
			Instantiate(deathPartical,other.transform.position,transform.rotation);
			handdler.AddSocre();

		}
			if(other.gameObject.tag == "EnemyBullet")
		{
			
			Destroy(other.gameObject);
			Destroy(gameObject);
			Instantiate(blast,other.transform.position,other.transform.rotation);
		}
	}
}
