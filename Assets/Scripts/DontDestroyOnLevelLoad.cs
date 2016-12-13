using UnityEngine;
using System.Collections;

public class DontDestroyOnLevelLoad : MonoBehaviour
{	
	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
	}
}
