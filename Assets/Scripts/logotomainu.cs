using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class logotomainu : MonoBehaviour
{
	public Text dragonVSAliens;
	public GameObject gameImage;
	void Start ()
	{
		dragonVSAliens.enabled = false;
		gameImage.SetActive(false);
		StartCoroutine (DelayedAwake ());
	}
	IEnumerator DelayedAwake ()
	{
		yield return new WaitForSeconds(2f);
		gameImage.SetActive(true);
		dragonVSAliens.enabled = true;
		yield return new WaitForSeconds(2f);
		Application.LoadLevel(LevelInfo.MainMenu);

	}
}
