using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour  
{

	public GameObject PlrBltPower;
	public GameObject[] enemySpawn;
	public float enemySpawnCount = 7;
	public Vector3 spawnValues;
	public Text reStartText;
	public bool isGameOver;
	int waveCount;
	UIHandler UIHCSs;
	Music music;


	void Start () 
	{
		waveCount = 1;
		music = GameObject.FindObjectOfType(typeof(Music)) as Music;
		UIHCSs = GameObject.FindObjectOfType(typeof(UIHandler)) as UIHandler;


		reStartText.enabled = false;
		StartCoroutine(EnemySpawner());

	}



	void Update()
	{
		if( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && isGameOver)
		{
			isGameOver = false;
			Application.LoadLevel(Application.loadedLevel);

		}
	}


	IEnumerator EnemySpawner()
	{
		while(true)
		{
			for(int i = 0 ; i < enemySpawnCount ; i++)
			{

				if(isGameOver)
				{
					UIHCSs.waveCountText.enabled = false;
					isGameOver = false;
					yield return new WaitForSeconds(4f);
					reStartText.enabled = true;
					isGameOver = true;
					yield return new WaitForSeconds(4f);
					music.AfterGameOverPlay();
					break;
				}

				GameObject enemy = enemySpawn [Random.Range(0,enemySpawn.Length)];
				Vector3 enemySpawnPosition = new Vector3(spawnValues.x, Random.Range(-2,4), spawnValues.z);
				Quaternion enemyRotation = Quaternion.identity;
				Instantiate(enemy,enemySpawnPosition,enemyRotation);
				yield return new WaitForSeconds(1.3f);
			}

			if(waveCount == 2 || waveCount == 5 || waveCount == 8)
			{
				Vector3 plrBltPwrPos = new Vector3(spawnValues.x, Random.Range(-2,4), spawnValues.z);
				Instantiate(PlrBltPower,plrBltPwrPos,Quaternion.identity);
			}


			if(isGameOver)
			{					
				UIHCSs.waveCountText.enabled = false;
				isGameOver = false;
				yield return new WaitForSeconds(4f);
				reStartText.enabled = true;
				isGameOver = true;
				yield return new WaitForSeconds(4f);
				music.AfterGameOverPlay();
				break;
			}
			UIHCSs.WaveCount(enemySpawnCount);
			waveCount += 1;
			yield return new WaitForSeconds(3f);
			UIHCSs.waveCountText.enabled = false;
			enemySpawnCount += 5;

		}

	}



	public void IsGameOver()
	{
		isGameOver = true;
	}

	public bool IsGameOver1()
	{
		
		if(isGameOver)
			return false;
		else
			return true;
		
	}
}