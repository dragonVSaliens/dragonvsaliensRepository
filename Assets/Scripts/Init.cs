using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{

	void Awake ()
	{
		StartCoroutine (DelayedAwake ());
	}
	IEnumerator DelayedAwake ()
	{

		if (!GameObject.Find ("LoadingScreen"))
		{
			AsyncOperation op = Application.LoadLevelAdditiveAsync (LevelInfo.LoadingScreen);
			yield return op;
		}
		Application.LoadLevel(LevelInfo.Logo);
		yield return null;
	}
}
