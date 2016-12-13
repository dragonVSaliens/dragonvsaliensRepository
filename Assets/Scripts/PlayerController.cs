using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour 
{
	public GameObject gameOverChart;
	public float jumpSpeed = 1f;
	public float movingDownSpeed = 1f;
	public float forwarAndBackwardSpeed = 1f;
	public GameObject bullet;
	public Transform bulletPosition;
	public Transform bulletPosition1;
	public Transform bulletPosition2;
	public Transform bulletPosition3;
	GameController GameCS;
	LeftEnemySpawn leftESCS;
	UIHandler UIHCS;
	Music music;
	bool plrBltPwr;
	bool plrBltPwr1;
	bool plrBltPwr2;
	bool plrBltPwr3;
	int plrBltPwrCount = 0;

	void Start ()
	{
		//  some Initialisations. ..................................................
		plrBltPwrCount = 0;
		 plrBltPwr = true;
	  	 plrBltPwr1 = false;
		 plrBltPwr2 = false;
		 plrBltPwr3 = false;
		gameOverChart.SetActive(false);
		GameCS = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
		UIHCS = GameObject.FindObjectOfType(typeof(UIHandler)) as UIHandler;
		music = GameObject.FindObjectOfType(typeof(Music)) as Music;
		leftESCS = GameObject.FindObjectOfType(typeof(LeftEnemySpawn)) as LeftEnemySpawn;



	}

	// Checking for the Player Powerup Collisions. ..........................................
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "PowerBullet")
		{

			music.PlrPwrUpPlay();
				plrBltPwrCount += 1;

			if(plrBltPwrCount == 3)
				{
					plrBltPwr3 = true;
				}
			else if(plrBltPwrCount == 2)
				{
					plrBltPwr2 = true;
				}
				else
				{
					plrBltPwr1 = true;
				}
			Destroy(other.gameObject);
		}
	}

	void Update () 
	{
		// CLAMPING TO PLAYER TO UP AND DOWN 
		transform.position = new Vector3 (Mathf.Clamp (bulletPosition.parent.transform.position.x, -6,5), 
		                                  Mathf.Clamp (bulletPosition.parent.transform.position.y, -4,4),
		                                  bulletPosition.parent.position.z);

		// AUTO MOVINGDOWN PLAYER
		transform.Translate(0,movingDownSpeed * Time.deltaTime,0);


		// Checking For the below Platforms. ........................................................
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WEBGL

		// SAVING PLAYER MOVING VALUES VIA ARROW BUTTON
		float forwarAndBackward  = Input.GetAxis("Horizontal") * forwarAndBackwardSpeed;
		forwarAndBackward *= Time.deltaTime;
		
		// MOVING PLAYER WITH ARROW BUTTONS VIA SAVED VALUES
		transform.Translate (forwarAndBackward,0,0);
	
		// Player Flying. .........................................................
		if(Input.GetKey(KeyCode.Space))
		{
			PlayerFly();
		}

		// Player Firing. .........................................................
		if(Input.GetKeyDown(KeyCode.S))
		{
			PlayerFire();
		}
 
		// Checking for the below Platforms. ...............................................
		#elif UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR

		// SAVING PLAYER MOVING VALUES VIA GYROSCOPE. ...........................
		float forwarAndBackward  = Input.acceleration.x * forwarAndBackwardSpeed;
		forwarAndBackward *= Time.deltaTime;

		// MOVING PLAYER WITH GYROSCOPE SAVED VALUES. ..............................
		transform.Translate (forwarAndBackward,0,0);

		// Player Fire and Fly with Touches. ...............................................
		if(Input.touchCount > 0)
		{
			//for(int i=0; i < Input.touchCount; i++)
			foreach(Touch touch in Input.touches)
			{
				//Touch touch = Input.GetTouch(i);
				
				// player Flying
				if( touch.position.x < Screen.width * 0.5f )
				{
					PlayerFly();
				}
				
				
				// player fire
				if(touch.position.x > Screen.width * 0.5f && touch.phase == TouchPhase.Began)
				{
					PlayerFire();
				}
			}
		}

		#endif
		
	}


	public void PlayerFire()
	{
		
		if(plrBltPwr3)
		{	
			plrBltPwr = false;
			plrBltPwr1 = false;
			plrBltPwr2 = false;
			Instantiate(bullet,bulletPosition.position,bulletPosition.rotation); 
			Instantiate(bullet,bulletPosition1.position,bulletPosition.rotation); 
			Instantiate(bullet,bulletPosition2.position,bulletPosition.rotation); 
			Instantiate(bullet,bulletPosition3.position,bulletPosition.rotation); 
			
		}
		else if(plrBltPwr2)
		{	
			plrBltPwr = false;
			plrBltPwr1 = false;
			Instantiate(bullet,bulletPosition.position,bulletPosition.rotation); 
			Instantiate(bullet,bulletPosition1.position,bulletPosition.rotation); 
			Instantiate(bullet,bulletPosition2.position,bulletPosition.rotation); 
		}
		else if(plrBltPwr1)
		{	
			plrBltPwr = false;
			Instantiate(bullet,bulletPosition.position,bulletPosition.rotation); 
			Instantiate(bullet,bulletPosition1.position,bulletPosition.rotation); 
			
		}
		else if(plrBltPwr)
		{			
			Instantiate(bullet,bulletPosition.position,bulletPosition.rotation); 
		}
	}

	public void PlayerFly()
	{

			transform.Translate (0,jumpSpeed * Time.deltaTime ,0);
	}

	//GameOver
	public void GameOver()
	{

		music.BackGroundPause();
		music.GameOverPlay();
		GameCS.IsGameOver();
		leftESCS.IsGameOverLeftEnemy();
		UIHCS.HighScore();
		UIHCS.MaxCoins();
		gameOverChart.SetActive(true);
	}

}








