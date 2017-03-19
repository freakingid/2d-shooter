using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovingTargets : MonoBehaviour
{

	float timer = 0;
	public GameObject newObject;
	public GameObject bonus;
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
		float respawnTime = 5 / GameObject.Find ("gameManager").GetComponent<ManageShooterGame> ().difficulty;
		if (timer >= respawnTime) {
			float typeOfObjectSpawn = Random.Range (0, 100);
			GameObject t;
			if (typeOfObjectSpawn >= 50) {
				print ("Spawning a target");
				t = (GameObject)(Instantiate (newObject, newPosition, Quaternion.identity));
				t.GetComponent<ManageTargetHealth> ().type = ManageTargetHealth.TARGET_BOULDER;
			} else {
				print ("Spawning a bonus");
				t = (GameObject)(Instantiate (bonus, newPosition, Quaternion.identity));
			}
			timer = 0;
		}
	}
}
