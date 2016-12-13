using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIHandler :  MonoBehaviour
{
	bool noob;
	public GameObject no1Cup;
	public Text lifeCountText;
	public Text waveCountText;
	public Text highScoreText;
	public Text scoreText;
	public Text coinText;
	public Text MaxCoinsText;
	static int highScore = 0 ;
	private int  score = 0 ;
	private int coin = 0 ;
	static int maxCoins = 0;
	static int waveCount = 0;
	int maxxlife = 4;
	int coin100 = 60;
	int lifeCount = 3;
	public GameObject lifeSpawn;
	PlayerController playerCS;
	DestroyOnCon destroyONCS;
	private float playerTagCount = 0;


	void Start () 
	{	noob = false;
		maxxlife = 4;
		waveCount = 0;
		lifeCount = 4;
		coin100 = 60;
		no1Cup.SetActive(false);
		waveCountText.enabled = false;
		highScoreText.enabled = false;
		MaxCoinsText.enabled = false;
		highScore = PlayerPrefs.GetInt("highScore", 0);
		maxCoins = PlayerPrefs.GetInt("maxCoins",0);
		playerCS = GameObject.FindObjectOfType(typeof(PlayerController)) as PlayerController;
		destroyONCS = GameObject.FindObjectOfType(typeof(DestroyOnCon)) as DestroyOnCon;


	}

	void Update()
	{
		lifeCountText.text = "x " + lifeCount;

	}

	public void AddSocre()
	{
		score += 1; 
		playerTagCount += 1;
		scoreText.text = "Score : " + score  ;
		if(score > highScore) 
		{
			noob = true;
			highScore = score;

		}
	}
	public void HighScore()
	{
		if(noob)
		{
			no1Cup.SetActive(true);
		}
		highScoreText.enabled = true;
		highScoreText.text = " = " + highScore + " Best" ;
		PlayerPrefs.SetInt("highScore", highScore);
	}

	public void AddCoin()
	{
	
		coin += 1;
		coinText.text = "x " + coin;
		if( coin == coin100)
		{
			coin100 += 60;
			maxxlife += 1;
		}
		if(coin > maxCoins) 
		{
			maxCoins = coin;
		}
	}
	public void MaxCoins()
	{
		MaxCoinsText.enabled = true;
		MaxCoinsText.text = " = "  + maxCoins + " Max" ;
		PlayerPrefs.SetInt("maxCoins", maxCoins);
	}


	public void SubLife()
	{
		if(lifeCount != 0 )
		{
			--lifeCount;
		}
		if(lifeCount == 0)
		{
			playerCS.GameOver();
			destroyONCS.DestroyPlayer();
		}
	}
	
	public void AddLife()
	{

		if(lifeCount < maxxlife )
		{
			lifeCount +=  1;
		}
	}

	public void  WaveCount(float enemySpawnCount)
	{	

		var xx = enemySpawnCount * 0.25f;
		LifeCreate(xx);
		waveCountText.enabled = true;
		waveCount += 1;
		waveCountText.text = "Wave : " + waveCount;

	}



	public void LifeCreate(float xx)
	{

		if( playerTagCount >= xx )
		{
			var randomPosition = new Vector3(transform.position.x,Random.Range(-2,4),transform.position.z);
			Instantiate(lifeSpawn,randomPosition,Quaternion.identity);
			playerTagCount = 0;
		}
		playerTagCount = 0;
	}

}





