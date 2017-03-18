using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTargetHealth : MonoBehaviour {
	public int health, type;
	public static int TARGET_BOULDER=0;
	public static int TARGET_BOULDER_MEDIUM=1;
	public static int TARGET_BOULDER_LARGE=2;

	// Use this for initialization
	void Start () {
		// Set health based on the type of target
		switch (type) {
		case 0:
			health = 20;
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
			break;
		case 1:
			health = 30;
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
			break;
		case 2:
			health = 40;
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			break;
		default:
			health = 20;
			gameObject.GetComponent<Renderer> ().material.color = Color.white;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gotHit(int damage){
		health -= damage;
		if (health <= 0) {
			destroyTarget ();
		}
	}

	public void destroyTarget(){
		// destroy the object linked to this script (like 'self')
		Destroy (gameObject);
	}
}
