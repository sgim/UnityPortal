﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Networking;
using SimpleJSON;

public class Signup : MonoBehaviour {
	string username = "Enter Username ";
	string mail = "Enter Email";
	string password = "Enter Password";
	State state;


	void Start () {
		state = State.instance;
	}

	void OnGUI(){
		username = GUI.TextField (new Rect (278,240,160,30), username, 25);
		mail = GUI.TextField (new Rect (278,275,160,30), mail, 25);
		password = GUI.PasswordField (new Rect (278,310,160, 30), password, "*" [0], 25);
	}

	void Update () {
	if (Input.GetKeyDown (KeyCode.Return)) {
			PostSignup();
		}
	}

	public void BackToLogin(){
		state.LoadScene ("Login");
	}

	public void PostSignup(){
		StartCoroutine(UserAuthentification());
	}

	IEnumerator UserAuthentification()
	{
		WWWForm form = new WWWForm();
		form.AddField("name", username);
		form.AddField("email", mail);
		form.AddField("password", password);
		using (UnityWebRequest request = UnityWebRequest.Post (state.url + "api/users", form)) {
			yield return request.Send();

			if(request.isError) {
				Debug.Log(request.error);
			}
			else {
				JSONNode CurrentUser = JSON.Parse(request.downloadHandler.text)["user"];
				state.Login (mail, password);
			}
		}
	}
}