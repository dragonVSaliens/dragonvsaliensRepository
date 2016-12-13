using UnityEngine;
using System.Collections;
public class MuteUnMute : MonoBehaviour  
{
	public GameObject Mute;
	public GameObject UnMute;

	void Start()
	{
		UnMute.SetActive(false);
	}

}
