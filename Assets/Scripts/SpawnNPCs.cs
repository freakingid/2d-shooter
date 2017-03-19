﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPCs : MonoBehaviour
{
	public GameObject npc1;
	private float timer, respawnTime;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		float respawnTime = 5/GameObject.Find("gameManager").GetComponent<ManageShooterGame>().difficulty;
		if(timer >= respawnTime){
			timer = 0;
			SpawnNPC (npc1);
		}
	}

	void SpawnNPC (GameObject typeOfNPC)
	{
		// random to use as horizontal offset from player position
		float range = Random.Range (-10, 10);
		// position of new NPC
		Vector3 newPosition = new Vector3 (GameObject.Find ("Player").transform.position.x + range, transform.position.y, 0);
		// instande of NPC
		GameObject newNPC = (GameObject)(Instantiate (npc1, newPosition, Quaternion.identity));

		newNPC.transform.Rotate (new Vector3 (0, 0, 180));
		newNPC.name = "npc1";
	}
}