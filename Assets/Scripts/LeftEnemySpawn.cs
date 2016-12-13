using UnityEngine;
using System.Collections;

public class LeftEnemySpawn : MonoBehaviour 
{
	public Transform leftEnemyPos;

	public GameObject[] leftEnemy;

	public bool isGameOverLeftEnemy;

	void Start () 
	{
		isGameOverLeftEnemy = false;
		StartCoroutine(LeftEnemy());
	
	}

	IEnumerator LeftEnemy()
	{
		while (true)
		{
			yield return new WaitForSeconds(8f);
			if(isGameOverLeftEnemy)
			{
				isGameOverLeftEnemy = false;
				break;
			}

			GameObject enemy = leftEnemy [Random.Range(0,leftEnemy.Length)];
			Instantiate(enemy,leftEnemyPos.position,Quaternion.Euler(0,180f,0));
			yield return new WaitForSeconds(20f);

		}
	}

	
	public void IsGameOverLeftEnemy()
	{
		isGameOverLeftEnemy = true;
	}


}
