using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Destroy bullet after 10 seconds, no matter what
		// Forget that, how about 3 seconds?
		Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Items colliding with bullet?
	void OnCollisionEnter2D(Collision2D coll) {
		// Is it tagged "target"?
		if(coll.gameObject.tag == "Target" ) {
			// Destroy the thing the bullet hit
			Destroy (coll.gameObject);
			// Destroy the bullet itself
			Destroy (gameObject);
		}
	}
}
