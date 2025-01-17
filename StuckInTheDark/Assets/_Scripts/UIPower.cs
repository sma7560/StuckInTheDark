﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPower : MonoBehaviour {

	private Text text;
	private Flashlight player;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		player = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Flashlight>();
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0)
			text.text = "";
		else if (Time.timeScale == 1) {

			try {
				float p = player.power;
				text.text = "ENERGY: " + Mathf.RoundToInt (p);

				if (p >= 75) {
					text.color = Color.green;
				} else if (p > 25) {
					text.color = Color.yellow;
				} else {
					text.color = Color.red;
				}

			} catch (System.NullReferenceException) {		//player is dead
				gameObject.SetActive (false);
			}
		}
	}
}
