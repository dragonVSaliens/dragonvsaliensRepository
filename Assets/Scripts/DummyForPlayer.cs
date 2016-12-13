using UnityEngine;
using System.Collections;

public class DummyForPlayer : MonoBehaviour {
	public Transform pos;
	public GameObject playerBullet;
	void Start () 
	{
		StartCoroutine(EnemyShot());
	}
	
	IEnumerator EnemyShot()
	{
		while(true)
		{
			var fr = Random.Range(0,6);
			Instantiate(playerBullet,pos.position,Quaternion.identity);
			yield return new WaitForSeconds(fr);
		}
	}


	
	
}
