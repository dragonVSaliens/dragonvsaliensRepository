using UnityEngine;
using System.Collections;

public class EneBultMover : MonoBehaviour {

	public float eneBuletMvngSpeed = -5;
	void Start () {
	
	}

	void Update () 
	{
		Vector3 moveforward = new Vector3 (0,eneBuletMvngSpeed * Time.deltaTime,0);
		transform.Translate(moveforward);
		Vector3 rotator = new Vector3(0,0,-90);
		transform.eulerAngles = rotator;

	
	}
}
