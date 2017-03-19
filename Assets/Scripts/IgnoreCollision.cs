using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int layer1 = GameObject.Find("npc1").layer;
		int layer2 = gameObject.layer;
		Physics2D.IgnoreLayerCollision (layer1, layer2, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
