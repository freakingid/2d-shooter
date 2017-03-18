using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovingTargets : MonoBehaviour
{

	float timer = 0;
	public GameObject newObject;
	private int newBoulderType;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		// random horizontal offset to left or right of player
		float range = Random.Range (-10, 10);
		// Make newPosition for spawning of new target
		// Player.x + range, position of object linked to this script (targetSpawner)
		Vector3 newPosition = new Vector3 (GameObject.Find ("Player").transform.position.x + range, transform.position.y, 0);
		// Spawn a new target every 2 seconds
		if (timer >= 2) {
			GameObject t = (GameObject)(Instantiate (newObject, newPosition, Quaternion.identity));
			// Randomly decide what boulder type
			newBoulderType = Random.Range (0, 3);
			// Set the boulder type accordingly; This should also set color when it sets the health amount;
			t.GetComponent<ManageTargetHealth> ().type = newBoulderType;
			// Start over for creating new target
			timer = 0;
		}
	}
}
