using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTargetHealth : MonoBehaviour {
	public int health, type;
	public static int TARGET_BOULDER=0;

	// Use this for initialization
	void Start () {
		// Set health based on the type of target
		if (type == TARGET_BOULDER) {
			health = 20;
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
