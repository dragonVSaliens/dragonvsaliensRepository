using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {

	public GameObject enemyBullet;
	void Start () 
	{
		StartCoroutine(EnemyShot());
	}

	IEnumerator EnemyShot()
	{
		while(true)
		{
			var fr = Random.Range(3,6);
			Instantiate(enemyBullet,transform.position,Quaternion.identity);
			yield return new WaitForSeconds(fr);
		}
	}
	

}
