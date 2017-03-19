using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePlayerHealth : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Target") {
			// Player collided with object tagged "target"
			// Destroy the target
			Destroy (coll.gameObject);
			DestroyPlayer ();
		}
	}

	void DestroyPlayer ()
	{
		// Just reloads the scene from the beginning, like room.restart in GM
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
