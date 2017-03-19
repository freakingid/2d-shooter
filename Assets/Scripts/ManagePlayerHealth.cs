using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePlayerHealth : MonoBehaviour
{
	public float timerForShield;
	public bool startInvincibility;
	// Use this for initialization
	void Start ()
	{
		GameObject.Find ("shield").GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startInvincibility) {
			// turn on the shield
			timerForShield += Time.deltaTime;
			if (timerForShield >= 20) {
				timerForShield = 0;
				startInvincibility = false;
				GameObject.Find ("shield").GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Target" || coll.gameObject.tag == "Bullet" && !startInvincibility) {
			// Player collided with object tagged "target" or "bullet" (wait, case sensitive.)
			// Also, our shield is not active
			// Destroy the target
			Destroy (coll.gameObject);
			DestroyPlayer ();
		}

		if (coll.gameObject.tag == "Bonus") {
			Destroy (coll.gameObject);
			startInvincibility = true;
			GameObject.Find ("shield").GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void DestroyPlayer ()
	{
		// Just reloads the scene from the beginning, like room.restart in GM
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
