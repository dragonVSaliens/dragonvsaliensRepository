using UnityEngine;
using System.Collections;

public class MainMenuButtonController : MonoBehaviour {

	public GameObject Mainmenu;
	public GameObject help;

	void Start () {
		Mainmenu.SetActive(true);
		help.SetActive(false);
	}
	

	public void OnHelpMenu()
	{
		help.SetActive(true);
		Mainmenu.SetActive(false);
	}
	public void OnBackMenu()
	{
		help.SetActive(false);
		Mainmenu.SetActive(true);
	}
}
