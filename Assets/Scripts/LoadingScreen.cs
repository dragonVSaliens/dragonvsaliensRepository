using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	[SerializeField]
	GameObject rootObject;
	
	[SerializeField]
	Scrollbar loadingBar;

	AsyncOperation asyncOp;

	private static LoadingScreen inst;
	void Awake ()
	{
		inst = this;
		Hide ();
	}

	void Update ()
	{
		if (asyncOp != null)
			inst.loadingBar.size = asyncOp.progress;
//		else
//			Debug.LogError ("AsyncOp is null");
	}



	void OnLevelWasLoaded (int levelNo)
	{
		LoadingScreen.Hide ();
	}

	public static void Show ()
	{

		inst.rootObject.SetActive (true);
	}

	public static void Hide ()
	{
		inst.rootObject.SetActive (false);
	}

	public static void LoadScene (string lvlName)
	{
		inst.StartCoroutine (inst._LoadScene (lvlName));
	}


	IEnumerator _LoadScene (string lvlName)
	{
		//Time.timeScale = 1;
		Show ();
		yield return null;
		asyncOp = Application.LoadLevelAsync (lvlName);
		yield return asyncOp;
		asyncOp = null;
	}

}
