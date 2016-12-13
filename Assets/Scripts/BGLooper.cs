using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public int numBGPanels = 10;
	void Start() {

	}

	void OnTriggerEnter2D(Collider2D collider) 
	{

		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x += widthOfBGObject * numBGPanels - widthOfBGObject/numBGPanels;
		collider.transform.position = pos;

	}
}
