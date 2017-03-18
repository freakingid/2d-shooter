using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovingTargets : MonoBehaviour
{

	float timer = 0;
	public GameObject newObject;

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
			// This works, but do we have to do SpriteRenderer?
			// t.GetComponent<SpriteRenderer> ().color = Color.red;
			t.GetComponent<Renderer> ().material.color = Color.red;

			timer = 0;
		}
	}
}
