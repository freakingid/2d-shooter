using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{

	public GameObject bullet;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		// Player movement via arrow keys
		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.Translate (Vector3.left * 0.1f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.Translate (Vector3.right * 0.1f);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.transform.Translate (Vector3.up * 0.1f);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.transform.Translate (Vector3.down * 0.1f);
		}

		// Player firing bullet via spacebar
		if (Input.GetKeyDown (KeyCode.Space)) {
			// b is bullet; Adding GameObject with bullet sprite, Player.positon + offset up, WTF is Q.id?
			GameObject b = (GameObject)(Instantiate (bullet, transform.position + transform.up * 1.5f, Quaternion.identity));
			// Propel the bullet in the up direction. Is this relevant to rotation of the Player?
			b.GetComponent<Rigidbody2D> ().AddForce (transform.up * 1000);
		}
	}
}
