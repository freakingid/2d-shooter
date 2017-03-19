﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageShooterGame : MonoBehaviour {
	public float timer;
	public float difficulty;
	public float timerThreshold;

	// Use this for initialization
	void Start () {
		timer = 0;
		difficulty = 1;
		timerThreshold = 5; // difficulty increases after 5 seconds
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timerThreshold) {
			difficulty++;
			print ("Difficulty level: " + difficulty);
			timer = 0;
		}
	}
}
