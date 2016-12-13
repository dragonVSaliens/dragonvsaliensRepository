using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float moveSpeed = -3f;
	void Update()
	{
		transform.Translate (moveSpeed * Time.deltaTime ,0,0);

	}
	

}
