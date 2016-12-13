using UnityEngine;
using System.Collections;

public class CoinControler : MonoBehaviour 
{
	public GameObject Coin;
	GameController GameCS;
	void Start () 
	{
		GameCS = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
		StartCoroutine(CoinSpawner());
	
	}

	IEnumerator CoinSpawner()
	{
		while(true)
		{
			var randomCoins = Random.Range(0,6);
			var randomPosition = new Vector3(transform.position.x,Random.Range(-2,4),transform.rotation.z);

			for(int i = 0 ; i < randomCoins ; i++)
			{
				if(GameCS.IsGameOver1())
				{
				Instantiate(Coin,randomPosition,Quaternion.identity);
				yield return new WaitForSeconds(0.7f);
				}
			}
			yield return new WaitForSeconds(3);


		}
	}

}
