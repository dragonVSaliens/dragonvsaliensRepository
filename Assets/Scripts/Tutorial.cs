using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	
	public GameObject tutorialobj;
	public GameObject titltingobj;
	// Use this for initialization
	void Start () 
	{
			titltingobj.SetActive(false);
			StartCoroutine(tutorialControl());
	
	}
	
	// Update is called once per frame
	IEnumerator tutorialControl ()
	{
		tutorialobj.SetActive(true);
		yield return new WaitForSeconds(3f);
		tutorialobj.SetActive(false);
		yield return new WaitForSeconds(1f);
		titltingobj.SetActive(true);
		yield return new WaitForSeconds(3f);
		titltingobj.SetActive(false);
	}
}
