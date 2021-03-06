﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {
	public bool enterOnce = true;
	public float showDuration = 3.0f;
	public bool isCheckpoint = false;
	public string txtmessage = "Enter Text";

	private bool alreadyEntered = false;
	private float enteredTime;
	private float currentTime;
	private Text currentMsg;

	void Start(){

		currentMsg = GameObject.Find ("MessageCenter").GetComponent<Text>();
		if (isCheckpoint) {
			txtmessage = "Checkpoint!";
		}
	}

	void FixedUpdate() {
		currentTime = Time.time;
		if (alreadyEntered && currentMsg.text == txtmessage && Time.time - enteredTime > showDuration) {
			currentMsg.text = "";
			if (enterOnce) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (!alreadyEntered || !enterOnce) {
			enteredTime = Time.time;
			currentMsg.text = txtmessage;

			if(isCheckpoint) {
				// also update the respawn position to this checkpoint position;
				State.instance.SetRespawn(transform.position, transform.eulerAngles.y);
			};

			alreadyEntered = true;
		}
	}
		
}
