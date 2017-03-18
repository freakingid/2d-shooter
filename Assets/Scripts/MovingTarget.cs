using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.down * 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
