﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public string Level1;
	public string SceneToLoad;
	public Canvas LogInMenu;
	public Canvas SignUpMenu;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
		LogInMenu = LogInMenu.GetComponent<Canvas> ();
		LogInMenu.enabled = false;
//		SignUpMenu = LogInMenu.GetComponent<Canvas> ();
//		SignUpMenu.enabled = false;
	}
	
	public void ExitPress()
	{
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress()
	{
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (Level1);   // load Scene
	}

	public void LoadScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (SceneToLoad);
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void LogIn(){
		LogInMenu.enabled = true;
		SignUpMenu.enabled = false;
	}

	public void SignUp(){
		LogInMenu.enabled = false;
		SignUpMenu.enabled = true;
	}

}
